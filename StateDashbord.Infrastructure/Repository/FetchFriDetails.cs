using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class FetchFriDetails : IFetchFriDetails
    {

        private readonly HttpClient _httpClient;
        public FetchFriDetails(HttpClient httpClient)
        {
            _httpClient = httpClient;


        }
        public async Task<Result<List<FRIDetailDto>>> FetchFriFromApi(FriRequest friRequest)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            string responseFromServer = "";

            try
            {

                // Set up a cancellation token with a 30-second timeout

                using var httpClient = new HttpClient();

                // JSON payload

                var payload = new
                {
                    from_date = "2020-01-01",
                    to_date = "2020-01-01",
                };


                // Serialize the payload to JSON
                var jsonContent = new StringContent(JsonSerializer.Serialize(friRequest), Encoding.UTF8, "application/json");

                // Add headers
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                // Send the HTTP POST request
                HttpResponseMessage response = await httpClient.PostAsync("http://egujcop.gujarat.gov.in:7004/hdiits/rest/SCRBWebService/getFIRDetailsForNirbhaya", jsonContent, cts.Token);
                response.EnsureSuccessStatusCode();

                // await Task.Delay(TimeSpan.FromSeconds(70));


                // Read and process the response
                var content = await response.Content.ReadAsStringAsync(cts.Token);
                    var dd = "{\"PS_Details_SCRB\":{\"ps_cd\":\"5678\",\"ps_name\":\"Pardi\",\"fir_reg_num\":\"11200038200001\",\"reg_dt\":\"2020-01-01\",\"state_name\":\"Gujarat\",\"city_district_name\":\"Valsad\",\"city_district_cd\":\"19\",\"address\":\"Pardi P.Stn., On N.H.No.8,  Pardi Ta.Pardi , \",\"latitude\":\"72.950000\",\"longitude\":\"20.520000\",\"crimehead_desc_guj\":\"નશાબંધી અધિનિયમ\",\"fir_gist_regional\":\"પ્રોહી.એકટ કલમ 66(1)(B),85(1)  મુજબ ઉપર બતાવેલ તા.ટા તથા જગ્યાએ આ કામના પકડાયેલ તહો અનીલ દબધન પ્રધાન ઉ.વ.૨૧ રહે.ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા નાનો વગર પાસ પરમીટે દારૂનો નશો કરી, નશાની હાલતમાં બેસી આવી પકડાઇ જઇ  ગુન્હો કર્યા વિગેરે બાબત\"},\"acts\":[{\"act_id\":\"4498\",\"section_code\":\"66(1)(b),85(1)\",\"act_desc\":\"નંશાબંધી અધિનિયમ, 1949\",\"section_desc\":\"Penalty for illegal cultivation and collection of hemp and other matters\"}],\"Complainant_Details_SCRB\":{\"comp_pres_address\":\"\",\"comp_pres_address_regional\":\"\",\"comp_name\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"comp_name_regional\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"mobileno\":\"\"},\"Occurrence_of_Offence\":{\"to_dt\":\"2020-01-01\",\"from_time\":\"18:40:00\",\"from_dt\":\"2019-12-31\",\"to_time\":\"00:05:00\"},\"Investigating_Officer\":{\"io_rank\":\"H.C.\",\"io_name\":\"Jagajivanbhai Dineshbhai Patel \",\"io_name_regional\":\"જગજીવનભાઇ દિનેશકુમાર  પટેલ \"},\"accused_list\":[{\"accused_name\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_name_regional\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_age\":\"21\",\"accused_pres_addr\":\"Surat City,Gujarat,\",\"accused_pres_addr_regional\":\"ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,સુરત શહેર,ગુજરાત,\",\"accused_national_gender_cd\":\"M\",\"accused_occupation\":\"\"}],\"Visiting_Details_SCRB\":{\"visiting_offcr_name\":\"\",\"visiting_offcr_dsgn\":\"\",\"visiting_date\":\"\",\"visiting_time\":\"\"}},{\"PS_Details_SCRB\":{\"ps_cd\":\"5808\",\"ps_name\":\"Sector-21\",\"fir_reg_num\":\"11216007200001\",\"reg_dt\":\"2020-01-01\",\"state_name\":\"Gujarat\",\"city_district_name\":\"Gandhinagar\",\"city_district_cd\":\"26\",\"address\":\"Sector-21 Police Station , \",\"latitude\":\"74.125000\",\"longitude\":\"23.124000\",\"crimehead_desc_guj\":\"નશાબંધી અધિનિયમ\",\"fir_gist_regional\":\"એવી રીતે કે ઉપર જણાવેલ તા.ટા અને જગ્યાએ આ કામના આરોપીએ ગે.કા અને વગર પાસ પરમીટે દારૂ પીધેલ હાલતમા જાહેરમા લથ્થડીયા ખાતો લવરી બકવાટ કરતો મળી આવી પકડાઇ જઇ ગુન્હો કર્યા વિ. બાબત\"},\"acts\":[{\"act_id\":\"4498\",\"section_code\":\"66(1)(b),85(1)\",\"act_desc\":\"નંશાબંધી અધિનિયમ, 1949\",\"section_desc\":\"Penalty for illegal cultivation and collection of hemp and other matters\"}],\"Complainant_Details_SCRB\":{\"comp_pres_address\":\"\",\"comp_pres_address_regional\":\"\",\"comp_name\":\"આ.પો.કોન્સ.અજયસિંહ પ્રદ્યુમનસિંહ બ.નં-૧૬૧૪ \",\"comp_name_regional\":\"આ.પો.કોન્સ.અજયસિંહ પ્રદ્યુમનસિંહ બ.નં-૧૬૧૪ \",\"mobileno\":\"9904066591\"},\"Occurrence_of_Offence\":{\"to_dt\":\"2019-12-31\",\"from_time\":\"23:50:00\",\"from_dt\":\"2019-12-31\",\"to_time\":\"23:50:00\"},\"Investigating_Officer\":{\"io_rank\":\"A.S.I.\",\"io_name\":\"Magansinh Bhimsinh Ayadi\",\"io_name_regional\":\"મગનસિહ ભીમસિહ આયડી\"},\"accused_list\":[{\"accused_name\":\"મનીષભાઇ  અશોકભાઇ  ઠક્કર  \",\"accused_name_regional\":\"મનીષભાઇ  અશોકભાઇ  ઠક્કર  \",\"accused_age\":\"30\",\"accused_pres_addr\":\"Sanand,Sanand,Ahmedabad Rural,Gujarat,\",\"accused_pres_addr_regional\":\"મ.નં-૮૫/૨,નાણાંની ભાગોળ,,સાણંદ,સાણંદ,અમદાવાદ ગ્રામ્ય,ગુજરાત,\",\"accused_national_gender_cd\":\"M\",\"accused_occupation\":\"\"}],\"Visiting_Details_SCRB\":{\"visiting_offcr_name\":\"\",\"visiting_offcr_dsgn\":\"\",\"visiting_date\":\"\",\"visiting_time\":\"\"}}";
                    var movieList = JsonSerializer.Deserialize<List<FRIDetailDto>>(dd);
               
                return Result<List<FRIDetailDto>>.SuccessResult(movieList,"fechdata succesfull",1);
            }
            catch (TaskCanceledException ex) when (!cts.Token.IsCancellationRequested)
            {

                Console.WriteLine("The request timed out.");
                return Result<List<FRIDetailDto>>.FailureResult(ex.ToString(), 0);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return Result<List<FRIDetailDto>>.FailureResult(ex.ToString(), 0);

            }

        }
    }
}
