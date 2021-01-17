# GenericCSVSanitiser
 A basic version of a CSV Sanitiser used for a data-based project.
 Will take two columns of data from a spreadsheet and export them into a seperate csv.
 
To use the program you must use 3 arguments:
- [0] = The target CSV file
- [1] = The columns that will be used as lat/longt in format "column(0,1)" 
      (if the first and second columns contain the lat and longt; 0 based)
- [2] = The location being filtered; such as Victoria. Only supports Victoria at the moment
      utilising a [C# ReverseGeocoding Library](https://github.com/redmanmale/ReverseGeocoder) and 
      an associated city database for the selected state. 

*eg. GenericCSVSanitiser.exe woolies.csv column(0,1) Victoria
It will output a sanitised file with only the data values corresponding to Victoria.

