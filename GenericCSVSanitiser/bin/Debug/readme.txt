[Generic CSV Sanitiser]
For use on other CSVs other than specifically the crowd movement data.
This includes imported CSVs to the dashboard systems such as trainstations and
shopping locations which can also contribute to the parcel placement.

To use the program you must use 3 arguments:
[0] = The target CSV file
[1] = The columns that will be used as lat/longt in format "column(0,1)" 
      (if the first and second columns contain the lat and longt)
[2] = The location being filtered; such as Victoria. Only supports Victoria at the moment
      utilising the same ReverseGeocoding and City to State Translation as the DataSanConsole

*eg. GenericCSVSanitiser.exe woolies.csv column(0,1) Victoria
It will output a sanitised file with only the data values corresponding to Victoria.
Can be adapted to filter other CSV types.

