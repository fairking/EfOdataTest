# EfOdataTest

Testing [EntityFrameworkCore](https://github.com/dotnet/efcore), [Automapper](https://github.com/AutoMapper/AutoMapper) and [Odata](https://github.com/OData/WebApi) together

List of tests:
- OK `https://localhost:5001/odata/weatherforecast`
- OK `https://localhost:5001/odata/weatherforecast?$orderby=temperatureF`
- OK `https://localhost:5001/odata/weatherforecast?$filter=summary eq 'Warm'`
- OK `https://localhost:5001/odata/weatherforecast?$select=id,summary`
- ERROR `https://localhost:5001/odata/weatherforecast?$apply=groupby((summary), aggregate(temperatureC with average as total))`

Related issues: 
- https://github.com/nhibernate/nhibernate-core/issues/2334
- https://github.com/OData/WebApi/issues/2015
- https://github.com/DataObjects-NET/dataobjects-net/issues/13


EntityFrameworkCore test: https://github.com/fairking/EfOdataTest

NHibernate test: https://github.com/fairking/NhOdataTest

DataObjects.NET test: https://github.com/fairking/DoOdataTest
