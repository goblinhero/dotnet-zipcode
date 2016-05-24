# xena-zipcode
Xena Microservice for Zipcodes

# API
     /{country}/Zip/{zip} country: 2-letter ISO standard (currently DK and NO are supported), zip: zip code to search for

Returns a single zip if found, otherwise a 404 is returned.

    /{country}/Search country: 2-letter ISO standard (currently DK and NO are supported)

Returns 10 first zip codes for the country.
