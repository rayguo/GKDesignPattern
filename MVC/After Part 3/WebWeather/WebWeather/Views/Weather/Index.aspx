<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebWeather.Models.WeatherStationsModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
        <h1>Weather History</h1>
        <% foreach (string station in Model.Stations)
           { %>
            <%: station%>
        <% } %>
    </div>
</body>
</html>
