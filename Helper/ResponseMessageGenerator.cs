using Minder.Enum;

namespace Minder.Helper
{
    public static class ResponseMessageGenerator
    {
        public static readonly Dictionary<ResponseStatusCodes, string> ResponseMessages = new Dictionary<ResponseStatusCodes, string>
        {
            {ResponseStatusCodes.Success,"Başarılı İşlem"},
            {ResponseStatusCodes.AccountNotFound,"Kullanıcı bulunamadı."},
            {ResponseStatusCodes.AccountFound,"Böyle bir kullanıcı mevcut."},
            {ResponseStatusCodes.ExistData,"Böyle bir veri mevcut"},
            {ResponseStatusCodes.DataNotFound,"Böyle bir veri bulunamadı"}
        };

        public static string MessageGenerator(ResponseStatusCodes responseStatusCodes)
        {
            return ResponseMessages[responseStatusCodes];
        }
    }
}