using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDemo.Models.Data;
using TestDemo.Models.Entities;
using TestDemo.Models.Values;

namespace TestDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    //БД
    private readonly TestContext _db;

    public TestController(TestContext db)
    {
        _db = db;
    }

    
    //метод принимающий 'uri' c xml данными и сохраняет БД return: указывается кол-во внесенных в таблицу записей
    [HttpGet("/currency/save/{date}")]
    public JsonResult Get(string date)
    {
        try
        {
            var rates = DeserializeXmlWithUrl<Rates>(date);
            var rCurrnecies = ConvertRatesToRCurrnecy(rates);
            _db.RCurrencies.AddRangeAsync(rCurrnecies);
            var countChanges =  _db.SaveChanges();
            return new JsonResult(new Quantity(countChanges));
        }
        catch
        {
            return new JsonResult(date);
        }
    }

    //метод принимающий 'date'- DateTime, 'code' - валюта и выборку из таблицы R_CURRENCY по полям A_Date, Code
    [HttpGet("/currency/{date}")]
    public async Task<List<R_CURRENCY>> Get(string date, string? code)
    {
        //проверка дату
        if (DateTime.TryParse(date, out var dateParse)) 
        {
            // проверка 'code' на null or empty
            return string.IsNullOrEmpty(code)                   
                ? await _db.RCurrencies.Where(r => r.A_Date== dateParse).ToListAsync() //true
                : await _db.RCurrencies.Where(r => r.A_Date == dateParse && r.Code == code).ToListAsync(); //false
        }
        return new();
    }

    //десериализация по uri c XML->object
    private T DeserializeXmlWithUrl<T>(string url)
    {
        var serializer = new XmlSerializer(typeof(T));
        var reader = new XmlTextReader(HttpUtility.UrlDecode(url));
        return (T)serializer.Deserialize(reader);
    }

    //преобразование объектов rates на RCurrnecy
    private List<R_CURRENCY> ConvertRatesToRCurrnecy(Rates rates)
    {
        var rCurList = new List<R_CURRENCY>();
        rates.Items.ForEach(r => rCurList.Add(new R_CURRENCY
        {
            Title = r.Fullname, Code = r.Title, Value = r.Description, A_Date = DateTime.Parse(rates.Date)
        }));
        return rCurList;
    }
}