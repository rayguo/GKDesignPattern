<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebWeather.Models.WeatherStationModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>List</title>
</head>
<body>
    <div>
        <h2><%: Model.Name %></h2>

        

        <% if ( Model.CanPrev )%>
            <%= Html.ActionLink( "Prev" , "List" , new { page = Model.PageNumber -1 } ) %>

        <% if ( Model.CanNext )  %>
            <%= Html.ActionLink( "Next" , "List" , new { page = Model.PageNumber +1 } ) %>

        <br />
        <table border="1">
            <tr>
             <th>  Year     </th>
             <th> Month </th>
             <th>  Min      </th>
             <th>  Max      </th>
             <th> Rainfall  </th>
            </tr>

            <% foreach( WeatherLibrary.WeatherSample sample in Model.Samples ) { %>
            <tr>
                <td><%: sample.Year %></td>
                <td><%: sample.Month %></td>
                 <td><%: sample.MinTemperature %></td>
                <td><%: sample.MaxTemperature %></td>
                <td><%: sample.RainFall %></td>
            </tr>

            <% } %>
        </table>
    </div>
</body>
</html>
