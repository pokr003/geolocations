namespace Geolocations.API.Modules.Currency;
public class CurrencyQuery
{
    public string? ISOCode { get; set; }
    public int? ISONumber { get; set; }
    public int Limit { get; set; } = 25;
    public int Skip { get; set; } = 0;
    public string?[] Fields { get; set; } = [];

    public static ValueTask<CurrencyQuery> BindAsync(HttpContext context)
    {
        var query = new CurrencyQuery();

        var queries = context.Request.Query.Where(q => !string.IsNullOrWhiteSpace(q.Value));

        foreach (var (key, value) in queries)
        {
            if (key == "iso_code") query.ISOCode = value[0];
            if (key == "iso_number") query.ISONumber = Convert.ToInt32(value[0]);
            if (key == "limit") query.Limit = Convert.ToInt32(value[0]);
            if (key == "skip") query.Skip = Convert.ToInt32(value[0]);
            if (key == "fields")
            {
                var fields = value[0];

                if (fields is not null)
                {
                    query.Fields = fields.Split(",");
                }
            }
        }

        return ValueTask.FromResult(query);
    }
}