using Microsoft.IdentityModel.Tokens;

internal class SigningCrenditials
{
    private SymmetricSecurityKey securityKey;
    private string hmacSha256Signature;

    public SigningCrenditials(SymmetricSecurityKey securityKey, string hmacSha256Signature)
    {
        this.securityKey = securityKey;
        this.hmacSha256Signature = hmacSha256Signature;
    }
}