using ExternalIntegration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalIntegration.Validations {
    public class ValidationController {

        public static string verifyTelstarRequest(TelstarRequest telstarRequest) {
            //Check company
            CompanyEnum company;
            try {
                company = (CompanyEnum)Enum.Parse(typeof(CompanyEnum), telstarRequest.Company);
            }
            catch (Exception e) {
                return "Invalid company";
            }

            //Check secret
            switch (company) {
                case CompanyEnum.OCEANIC_AIRLINES:
                    if (!telstarRequest.SecretCompanyCode.Equals(CompanySecrets.GetOceanicSecret())) {
                        return "Invalid secret";
                    }
                    break;
                case CompanyEnum.EAST_INDIA_TRADING:
                    if (!telstarRequest.SecretCompanyCode.Equals(CompanySecrets.GetIndiaSecret())) {
                        return "Invalid secret";
                    }
                    break;
                case CompanyEnum.TELSTAR_LOGISTICS:
                    if (!telstarRequest.SecretCompanyCode.Equals(CompanySecrets.GetTelstarSecret())) {
                        return "Invalid secret";
                    }
                    break;
            }

            //Check valid cities
            CityEnum cityFrom;
            CityEnum cityTo;
            try {
                cityFrom = (CityEnum)Enum.Parse(typeof(CityEnum), telstarRequest.CityFrom);
                cityTo = (CityEnum)Enum.Parse(typeof(CityEnum), telstarRequest.CityTo);
            }
            catch (Exception e) {
                return "Invalid city";
            }

            return null;
        }
    }
}
