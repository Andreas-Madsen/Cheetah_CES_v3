using ExternalIntegration.Enums;
using ExternalIntegration.Utils;
using System;
using System.Collections.Generic;

namespace ExternalIntegration.Validations {
    public class CommunicationValidation {
        /**
         * Check that the company secret is valid
         */
        public static string isCompanySecretValid(CompanyEnum company, string secret)
        {
            switch (company) 
            {
                case CompanyEnum.OCEANIC_AIRLINES:
                    if (!secret.Equals(CompanySecrets.GetOceanicSecret())) {
                        return "Invalid secret";
                    }
                    break;
                case CompanyEnum.EAST_INDIA_TRADING:
                    if (!secret.Equals(CompanySecrets.GetIndiaSecret())) {
                        return "Invalid secret";
                    }
                    break;
                case CompanyEnum.TELSTAR_LOGISTICS:
                    if (!secret.Equals(CompanySecrets.GetTelstarSecret())) {
                        return "Invalid secret";
                    }
                    break;
            }
            return null;
        }

        /**
         * Check that the cities are directly connected
         */
        public static string isCitiesDirect(CityEnum cityFrom, CityEnum cityTo) 
        {
            //TODO implement (direct routes will be in database)
            return null;
        }

        /**
         * Checks that the number is valid
         */
        public static string isNumberValid(int i) {
            if(i > 0)
            {
                return null;
            }
            return "Invalid value: " + i;
        }

        /**
         * Validates the request for telstar logistics
         */
        public static string verifyTelstarRequest(TelstarRequest telstarRequest) 
        {
            //Check company
            CompanyEnum company;
            try 
            {
                company = (CompanyEnum)Enum.Parse(typeof(CompanyEnum), telstarRequest.Company);
            }
            catch (Exception) 
            {
                return "Invalid company";
            }

            //Check company secret
            string secretError = isCompanySecretValid(company, telstarRequest.SecretCompanyCode);
            if(secretError != null) 
            {
                return secretError;
            }
            
            //Check valid cities
            CityEnum cityFrom;
            CityEnum cityTo;
            try 
            {
                cityFrom = (CityEnum)Enum.Parse(typeof(CityEnum), telstarRequest.CityFrom);
                cityTo = (CityEnum)Enum.Parse(typeof(CityEnum), telstarRequest.CityTo);
            } 
            catch (Exception) 
            {
                return "Invalid city";
            }

            //Check identical cities
            if(cityFrom == cityTo)
            {
                return "CityFrom cannot be equal to CityTo";
            }

            //Check if cities are directly connected
            string citiesDirectError = isCitiesDirect(cityFrom, cityTo);
            if (citiesDirectError != null)
            {
                return citiesDirectError;
            }

            //Check weight
            string weightError = isNumberValid(telstarRequest.Weight);
            if (weightError != null) {
                return weightError;
            }

            if(telstarRequest.Weight > 40) {
                return "Weight cannot be more than 40";
            }

            //Check width
            string widthError = isNumberValid(telstarRequest.Width);
            if (widthError != null) {
                return widthError;
            }

            //Check length
            string lengthError = isNumberValid(telstarRequest.Length);
            if (lengthError != null) {
                return lengthError;
            }

            //Check height
            string heightError = isNumberValid(telstarRequest.Height);
            if(heightError != null) {
                return heightError;
            }

            //Check features
            List<FeatureEnum> features = new List<FeatureEnum>();
            bool refSeen = false;
            bool animalSeen = false;
            bool cautioslySeen = false;
            string errorMsg = "Cannot transport refrigerated, animals and cautiosly in one delivery";
            foreach (string feature in telstarRequest.Features) {
                try {
                    FeatureEnum f = (FeatureEnum)Enum.Parse(typeof(FeatureEnum), feature);
                    features.Add(f);
                    if (f == FeatureEnum.WEAPONS) {
                        return "Weapons are not allowed";
                    }
                    
                    if (f == FeatureEnum.REFIGERATED) {
                        refSeen = true;
                        if(animalSeen || cautioslySeen) {
                            return errorMsg;
                        }
                    }

                    if (f == FeatureEnum.LIVE_ANIMALS) {
                        animalSeen = true;
                        if (refSeen || cautioslySeen) {
                            return errorMsg;
                        }
                    }

                    if (f == FeatureEnum.CAUTIOUSLY) {
                        cautioslySeen = true;
                        if (animalSeen || refSeen) {
                            return errorMsg;
                        }
                    }
                }
                catch (Exception) {
                    return "Invalid feature: " + feature;
                }
            }
            
            return null;
        }
    }
}
