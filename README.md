## Compare Multiple Sources

This is an expiremental project for creating a dsl around comparing the value
from multiple sources. The idea is that you have obtained data from three or
four locations and want to display them to the user.

```html
@using Sources
@model IEnumerable<SearchResultsCount<SearchResults>>

<h2>Google Search Results Counts</th>

<table>
  <thead>
    <tr>
      <th>Search Query</th>
      <th>Google</th>
      <th>Bing</th>
      <th>Yahoo</th>
    </tr>
  </thead>
  <tbody>
    @foreach (var term in Model)
    {
      <tr>
        <td>@term.Query</td>
        <td>@term.SourceValue(SearchResults.Google)</td>
        <td>@term.SourceValue(SearchResults.Bing)</td>
        <td>@term.SourceValue(SearchResults.Yahoo)</td>
      </tr>
    }
  </tbody>
</table>
```
