-- create a new .net core API project

dotnet new webapi -n az204-webapi
cd az204-webapi
code .


-- run 
dotnet run


-- visit the address
http://localhost:5019


-- Container:
docker buildx build --platform linux/amd64 --provenance=false -t az204demoacr.azurecr.io/az204-webapi:v2 --push .
docker buildx build --platform linux/amd64 --provenance=false -t az204demoacr.azurecr.io/az204-webapi:v3 --push .

docker run -d -p 8080:8080 --name az204-webapi az204-webapi


-- visit the address
http://localhost:8080


-- Push to ACR (bash CLI):

az login
az acr login --name az204demoacr
docker tag az204-webapi az204demoacr.azurecr.io/az204-webapi:v2
docker push az204demoacr.azurecr.io/az204-webapi:v2
az acr repository list --name az204demoacr --output table
az acr repository show-tags --name az204demoacr --repository az204-webapi --output table

-- use acr to build the new tag
az acr build --registry az204demoacr --image az204-webapi:v3 .


-- deploy to ACI using  portal, CLI, or powershell
http://20.253.8.152:8080/

-- aca make external
az containerapp ingress enable --name az204-demo-c1-aca --resource-group AZ204-RG --type external --target-port 8080
az containerapp show --name az204-demo-c1-aca --resource-group AZ204-RG --query "{fqdn:properties.configuration.ingress.fqdn,external:properties.configuration.ingress.external,targetPort:properties.configuration.ingress.targetPort}" -o json

-- visit
https://az204-demo-c1-aca.salmonflower-dbb67109.centralus.azurecontainerapps.io/