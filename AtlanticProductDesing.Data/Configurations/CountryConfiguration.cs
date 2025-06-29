namespace AtlanticProductDesing.Infrastruture.Configurations
{

    //TODO: Agregar el codigo de telefono en la data
    //public class CountryConfiguration : IEntityTypeConfiguration<Country>
    //{
    //    public void Configure(EntityTypeBuilder<Country> builder)
    //    {
    //        int i = 1;
    //        builder.HasData(
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Andorra",
    //                ISOAlpha2Code = "AD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Emiratos Árabes Unidos",
    //                ISOAlpha2Code = "AE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Afganistán",
    //                ISOAlpha2Code = "AF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Antigua y Barbuda",
    //                ISOAlpha2Code = "AG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Anguila",
    //                ISOAlpha2Code = "AI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Albania",
    //                ISOAlpha2Code = "AL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Armenia",
    //                ISOAlpha2Code = "AM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Antillas Neerlandesas",
    //                ISOAlpha2Code = "AN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Angola",
    //                ISOAlpha2Code = "AO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Antártida",
    //                ISOAlpha2Code = "AQ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Argentina",
    //                ISOAlpha2Code = "AR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Samoa Americana",
    //                ISOAlpha2Code = "AS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Austria",
    //                ISOAlpha2Code = "AT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Australia",
    //                ISOAlpha2Code = "AU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Aruba",
    //                ISOAlpha2Code = "AW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Áland",
    //                ISOAlpha2Code = "AX",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Azerbaiyán",
    //                ISOAlpha2Code = "AZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bosnia y Herzegovina",
    //                ISOAlpha2Code = "BA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Barbados",
    //                ISOAlpha2Code = "BB",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bangladesh",
    //                ISOAlpha2Code = "BD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bélgica",
    //                ISOAlpha2Code = "BE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Burkina Faso",
    //                ISOAlpha2Code = "BF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bulgaria",
    //                ISOAlpha2Code = "BG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bahréin",
    //                ISOAlpha2Code = "BH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Burundi",
    //                ISOAlpha2Code = "BI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Benin",
    //                ISOAlpha2Code = "BJ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "San Bartolomé",
    //                ISOAlpha2Code = "BL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bermudas",
    //                ISOAlpha2Code = "BM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Brunéi",
    //                ISOAlpha2Code = "BN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bolivia",
    //                ISOAlpha2Code = "BO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Brasil",
    //                ISOAlpha2Code = "BR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bahamas",
    //                ISOAlpha2Code = "BS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Bhután",
    //                ISOAlpha2Code = "BT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Isla Bouvet",
    //                ISOAlpha2Code = "BV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Botsuana",
    //                ISOAlpha2Code = "BW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Belarús",
    //                ISOAlpha2Code = "BY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Belice",
    //                ISOAlpha2Code = "BZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Canadá",
    //                ISOAlpha2Code = "CA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Cocos",
    //                ISOAlpha2Code = "CC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "República Centro-Africana",
    //                ISOAlpha2Code = "CF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Congo",
    //                ISOAlpha2Code = "CG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Suiza",
    //                ISOAlpha2Code = "CH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Costa de Marfil",
    //                ISOAlpha2Code = "CI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Cook",
    //                ISOAlpha2Code = "CK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Chile",
    //                ISOAlpha2Code = "CL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Camerún",
    //                ISOAlpha2Code = "CM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "China",
    //                ISOAlpha2Code = "CN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Colombia",
    //                ISOAlpha2Code = "CO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Costa Rica",
    //                ISOAlpha2Code = "CR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Cuba",
    //                ISOAlpha2Code = "CU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Cabo Verde",
    //                ISOAlpha2Code = "CV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Christmas",
    //                ISOAlpha2Code = "CX",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Chipre",
    //                ISOAlpha2Code = "CY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "República Checa",
    //                ISOAlpha2Code = "CZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Alemania",
    //                ISOAlpha2Code = "DE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Yibuti",
    //                ISOAlpha2Code = "DJ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Dinamarca",
    //                ISOAlpha2Code = "DK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Domínica",
    //                ISOAlpha2Code = "DM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "República Dominicana",
    //                ISOAlpha2Code = "DO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Argel",
    //                ISOAlpha2Code = "DZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Ecuador",
    //                ISOAlpha2Code = "EC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Estonia",
    //                ISOAlpha2Code = "EE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Egipto",
    //                ISOAlpha2Code = "EG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Sahara Occidental",
    //                ISOAlpha2Code = "EH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Eritrea",
    //                ISOAlpha2Code = "ER",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "España",
    //                ISOAlpha2Code = "ES",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Etiopía",
    //                ISOAlpha2Code = "ET",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Finlandia",
    //                ISOAlpha2Code = "FI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Fiji",
    //                ISOAlpha2Code = "FJ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Malvinas",
    //                ISOAlpha2Code = "FK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Micronesia",
    //                ISOAlpha2Code = "FM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Faroe",
    //                ISOAlpha2Code = "FO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Francia",
    //                ISOAlpha2Code = "FR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Gabón",
    //                ISOAlpha2Code = "GA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Reino Unido",
    //                ISOAlpha2Code = "GB",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Granada",
    //                ISOAlpha2Code = "GD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Georgia",
    //                ISOAlpha2Code = "GE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guayana Francesa",
    //                ISOAlpha2Code = "GF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guernsey",
    //                ISOAlpha2Code = "GG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Ghana",
    //                ISOAlpha2Code = "GH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Gibraltar",
    //                ISOAlpha2Code = "GI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Groenlandia",
    //                ISOAlpha2Code = "GL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Gambia",
    //                ISOAlpha2Code = "GM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guinea",
    //                ISOAlpha2Code = "GN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guadalupe",
    //                ISOAlpha2Code = "GP",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guinea Ecuatorial",
    //                ISOAlpha2Code = "GQ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Grecia",
    //                ISOAlpha2Code = "GR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Georgia del Sur e Islas Sandwich del Sur",
    //                ISOAlpha2Code = "GS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guatemala",
    //                ISOAlpha2Code = "GT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guam",
    //                ISOAlpha2Code = "GU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guinea-Bissau",
    //                ISOAlpha2Code = "GW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Guayana",
    //                ISOAlpha2Code = "GY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Hong Kong",
    //                ISOAlpha2Code = "HK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Heard y McDonald",
    //                ISOAlpha2Code = "HM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Honduras",
    //                ISOAlpha2Code = "HN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Croacia",
    //                ISOAlpha2Code = "HR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Haití",
    //                ISOAlpha2Code = "HT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Hungría",
    //                ISOAlpha2Code = "HU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Indonesia",
    //                ISOAlpha2Code = "ID",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Irlanda",
    //                ISOAlpha2Code = "IE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Israel",
    //                ISOAlpha2Code = "IL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Isla de Man",
    //                ISOAlpha2Code = "IM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "India",
    //                ISOAlpha2Code = "IN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Territorio Británico del Océano Índico	",
    //                ISOAlpha2Code = "IO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Irak",
    //                ISOAlpha2Code = "IQ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Irán",
    //                ISOAlpha2Code = "IR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islandia",
    //                ISOAlpha2Code = "IS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Italia",
    //                ISOAlpha2Code = "IT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Jersey",
    //                ISOAlpha2Code = "JE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Jamaica",
    //                ISOAlpha2Code = "JM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Jordania",
    //                ISOAlpha2Code = "JO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Japón",
    //                ISOAlpha2Code = "JP",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Kenia",
    //                ISOAlpha2Code = "KE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Kirguistán",
    //                ISOAlpha2Code = "KG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Camboya",
    //                ISOAlpha2Code = "KH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Kiribati",
    //                ISOAlpha2Code = "KI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Comoros",
    //                ISOAlpha2Code = "KM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "San Cristóbal y Nieves",
    //                ISOAlpha2Code = "KN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Corea del Norte",
    //                ISOAlpha2Code = "KP",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Corea del Sur",
    //                ISOAlpha2Code = "KR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Kuwait",
    //                ISOAlpha2Code = "KW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Caimán",
    //                ISOAlpha2Code = "KY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Kazajstán",
    //                ISOAlpha2Code = "KZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Laos",
    //                ISOAlpha2Code = "LA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Líbano",
    //                ISOAlpha2Code = "LB",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Santa Lucía",
    //                ISOAlpha2Code = "LC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Liechtenstein",
    //                ISOAlpha2Code = "LI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Sri Lanka",
    //                ISOAlpha2Code = "LK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Liberia",
    //                ISOAlpha2Code = "LR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Lesotho",
    //                ISOAlpha2Code = "LS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Lituania",
    //                ISOAlpha2Code = "LT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Luxemburgo",
    //                ISOAlpha2Code = "LU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Letonia",
    //                ISOAlpha2Code = "LV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Libia",
    //                ISOAlpha2Code = "LY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Marruecos",
    //                ISOAlpha2Code = "MA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mónaco",
    //                ISOAlpha2Code = "MC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Moldova",
    //                ISOAlpha2Code = "MD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Montenegro",
    //                ISOAlpha2Code = "ME",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Madagascar",
    //                ISOAlpha2Code = "MG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Marshall",
    //                ISOAlpha2Code = "MH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Macedonia",
    //                ISOAlpha2Code = "MK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mali",
    //                ISOAlpha2Code = "ML",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Myanmar",
    //                ISOAlpha2Code = "MM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mongolia",
    //                ISOAlpha2Code = "MN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Macao",
    //                ISOAlpha2Code = "MO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Martinica",
    //                ISOAlpha2Code = "MQ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mauritania",
    //                ISOAlpha2Code = "MR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Montserrat",
    //                ISOAlpha2Code = "MS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Malta",
    //                ISOAlpha2Code = "MT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mauricio",
    //                ISOAlpha2Code = "MU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Maldivas",
    //                ISOAlpha2Code = "MV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Malawi",
    //                ISOAlpha2Code = "MW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "México",
    //                ISOAlpha2Code = "MX",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Malasia",
    //                ISOAlpha2Code = "MY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mozambique",
    //                ISOAlpha2Code = "MZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Namibia",
    //                ISOAlpha2Code = "NA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nueva Caledonia",
    //                ISOAlpha2Code = "NC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Níger",
    //                ISOAlpha2Code = "NE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Norkfolk",
    //                ISOAlpha2Code = "NF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nigeria",
    //                ISOAlpha2Code = "NG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nicaragua",
    //                ISOAlpha2Code = "NI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Países Bajos",
    //                ISOAlpha2Code = "NL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Noruega",
    //                ISOAlpha2Code = "NO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nepal",
    //                ISOAlpha2Code = "NP",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nauru",
    //                ISOAlpha2Code = "NR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Niue",
    //                ISOAlpha2Code = "NU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Nueva Zelanda",
    //                ISOAlpha2Code = "NZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Omán",
    //                ISOAlpha2Code = "OM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Panamá",
    //                ISOAlpha2Code = "PA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Perú",
    //                ISOAlpha2Code = "PE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Polinesia Francesa",
    //                ISOAlpha2Code = "PF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Papúa Nueva Guinea",
    //                ISOAlpha2Code = "PG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Filipinas",
    //                ISOAlpha2Code = "PH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Pakistán",
    //                ISOAlpha2Code = "PK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Polonia",
    //                ISOAlpha2Code = "PL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "San Pedro y Miquelón",
    //                ISOAlpha2Code = "PM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Pitcairn",
    //                ISOAlpha2Code = "PN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Puerto Rico",
    //                ISOAlpha2Code = "PR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Palestina",
    //                ISOAlpha2Code = "PS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Portugal",
    //                ISOAlpha2Code = "PT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Palaos",
    //                ISOAlpha2Code = "PW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Paraguay",
    //                ISOAlpha2Code = "PY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Qatar",
    //                ISOAlpha2Code = "QA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Reunión",
    //                ISOAlpha2Code = "RE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Rumanía",
    //                ISOAlpha2Code = "RO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Serbia y Montenegro",
    //                ISOAlpha2Code = "RS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Rusia",
    //                ISOAlpha2Code = "RU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Ruanda",
    //                ISOAlpha2Code = "RW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Arabia Saudita",
    //                ISOAlpha2Code = "SA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Solomón",
    //                ISOAlpha2Code = "SB",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Seychelles",
    //                ISOAlpha2Code = "SC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Sudán",
    //                ISOAlpha2Code = "SD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Suecia",
    //                ISOAlpha2Code = "SE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Singapur",
    //                ISOAlpha2Code = "SG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Santa Elena",
    //                ISOAlpha2Code = "SH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Eslovenia",
    //                ISOAlpha2Code = "SI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Svalbard y Jan Mayen",
    //                ISOAlpha2Code = "SJ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Eslovaquia",
    //                ISOAlpha2Code = "SK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Sierra Leona",
    //                ISOAlpha2Code = "SL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "San Marino",
    //                ISOAlpha2Code = "SM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Senegal",
    //                ISOAlpha2Code = "SN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Somalia",
    //                ISOAlpha2Code = "SO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Surinam",
    //                ISOAlpha2Code = "SR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Santo Tomé y Príncipe",
    //                ISOAlpha2Code = "ST",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "El Salvador",
    //                ISOAlpha2Code = "SV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Siria",
    //                ISOAlpha2Code = "SY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Suazilandia",
    //                ISOAlpha2Code = "SZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas Turcas y Caicos",
    //                ISOAlpha2Code = "TC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Chad",
    //                ISOAlpha2Code = "TD",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Territorios",
    //                ISOAlpha2Code = "TF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Togo",
    //                ISOAlpha2Code = "TG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tailandia",
    //                ISOAlpha2Code = "TH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tanzania",
    //                ISOAlpha2Code = "TH",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tayikistán",
    //                ISOAlpha2Code = "TJ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tokelau",
    //                ISOAlpha2Code = "TK",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Timor",
    //                ISOAlpha2Code = "TL",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Turkmenistán",
    //                ISOAlpha2Code = "TM",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Túnez",
    //                ISOAlpha2Code = "TN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tonga",
    //                ISOAlpha2Code = "TO",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Turquía",
    //                ISOAlpha2Code = "TR",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Trinidad",
    //                ISOAlpha2Code = "TT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Tuvalu",
    //                ISOAlpha2Code = "TV",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Taiwán",
    //                ISOAlpha2Code = "TW",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Ucrania",
    //                ISOAlpha2Code = "UA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Uganda",
    //                ISOAlpha2Code = "UG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Estados",
    //                ISOAlpha2Code = "US",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Uruguay",
    //                ISOAlpha2Code = "UY",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Uzbekistán",
    //                ISOAlpha2Code = "UZ",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Ciudad",
    //                ISOAlpha2Code = "VA",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "San",
    //                ISOAlpha2Code = "VC",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Venezuela",
    //                ISOAlpha2Code = "VE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas",
    //                ISOAlpha2Code = "VG",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Islas",
    //                ISOAlpha2Code = "VI",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Vietnam",
    //                ISOAlpha2Code = "VN",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Vanuatu",
    //                ISOAlpha2Code = "VU",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Wallis",
    //                ISOAlpha2Code = "WF",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Samoa",
    //                ISOAlpha2Code = "WS",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Yemen",
    //                ISOAlpha2Code = "YE",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Mayotte",
    //                ISOAlpha2Code = "YT",
    //                PhoneCode = ""
    //            },
    //            new Country
    //            {
    //                Id = i++,
    //                Name = "Sudáfrica",
    //                ISOAlpha2Code = "ZA",
    //                PhoneCode = ""
    //            }
    //        );
    //    }
    //}


}
