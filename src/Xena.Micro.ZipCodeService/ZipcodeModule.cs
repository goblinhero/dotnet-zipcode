using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Responses;

namespace Xena.Micro.ZipCodeService
{
    public class ZipcodeModule : NancyModule
    {
        private ZipcodeRepository _repository = new ZipcodeRepository();
        public ZipcodeModule()
        {
            Get["/{country}/Zip/{zip}"] = p => GetZipcode(p.country,p.zip);
            Get["/{country}/Search"] = p => GetZipcodes(p.country);
        }

        private object GetZipcodes(string countryCode)
        {
            var country = new Country(countryCode);
            IList<Zipcode> zipCodes;
            IEnumerable<string> errors;
            if(_repository.GetZipByCountry(country, out zipCodes, out errors))
                return zipCodes;
            return new NotAcceptableResponse {ReasonPhrase = string.Join(Environment.NewLine,errors)};
        }

        private object GetZipcode(string countryCode,string zip)
        {
            var country = new Country(countryCode);
            Zipcode zipcode;
            if (_repository.TryGetZip(zip, out zipcode, country))
                return zipcode;
            return new NotFoundResponse();
        }
    }
}