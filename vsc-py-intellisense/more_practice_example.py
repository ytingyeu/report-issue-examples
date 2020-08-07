from azure.devops.connection import Connection
from msrest.authentication import BasicAuthentication

# examples takes from https://github.com/microsoft/azure-devops-python-api
# pip install azure-devops

# Fill in with your personal access token and org URL
personal_access_token = 'YOURPAT'
organization_url = 'https://dev.azure.com/YOURORG'

# Create a connection to the org
credentials = BasicAuthentication('', personal_access_token)
connection = Connection(base_url=organization_url, creds=credentials)

# Get a client (the "core" client provides access to projects, teams, etc)
core_client = connection.clients.get_core_client()

# Not able to list members with core_client
core_client.get_projects()
