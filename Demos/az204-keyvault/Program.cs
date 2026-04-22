using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

string keyVaultName = "az204-ordemo-kv";
string secretName = "myPassword";

string keyVaultUrl = $"https://{keyVaultName}.vault.azure.net/";

var client = new SecretClient(
    vaultUri: new Uri(keyVaultUrl),
    credential: new DefaultAzureCredential());

try
{
    KeyVaultSecret secret = await client.GetSecretAsync(secretName);

    Console.WriteLine($"Secret name: {secret.Name}");
    Console.WriteLine($"Secret value: {secret.Value}");
}
catch (Exception ex)
{
    Console.WriteLine("Failed to retrieve the secret.");
    Console.WriteLine(ex.Message);
}
