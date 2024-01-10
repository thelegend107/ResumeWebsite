# Resume Website - Static Web App!
## Setup
1. Created a free tier static web app in Azure and pointed the resource to this GitHub repository
2. Under the **API** folder, an Azure Function .NET 8 project was created
3. Installed Node.js v16.x.x. Newer versions do work fine but you may need to run the API manually as SWA and Azure Functions are compatible with v16. https://nodejs.org/en/blog/release/v16.20.2.
4. Installed SWA CLI. Visit https://azure.github.io/static-web-apps-cli/ for more info.
	`npm install -g @azure/static-web-apps-cli`
5. Under the **APP** folder, a Vue.js project was created.
 	`npm install -g @vue/cli`
	`npm create vue@latest`
	
7. In the root folder, the SWA local environment was initialized using `swa init`
8. Once the local environment was initialized, the APP and the API were ran using `swa start` from the root folder

## API
> The Azure Function is mainly retrieving the resume data from a SQL server database hosted on Azure. This database was provided by Azure for 12 months. Will be looking for an alternative soon. So more to come.


>API Documentation:
>https://documenter.getpostman.com/view/30870425/2s9YXnyyB3?fbclid=IwAR3ZtauhODr2Kc0z3isrIqO4t4jGtsxIBIY_T94G6Y0CjkxS_x4AF2CizH

## DEMO
> Domain name was acquired from namecheap.com. Azure allows you to bring your own domain for static web apps.

🚀 https://resume.thelegend107.com
