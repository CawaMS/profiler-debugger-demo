# Application Insights Profiler and Snapshot Debugger Sample Demo Web Application

## Overview
This walkthrough demonstrates you can easily use [Application Insights](https://azure.microsoft.com/services/application-insights/) to identify the line of code that slowed down the web app, as well as collect a snapshot for your web app and debug through the exceptions.
The two features of Application Insights we are experimenting with are:
    * [Application Insights Profiler](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-profiler)
    * [Application Insights Snapshot Debugger](https://docs.microsoft.com/azure/application-insights/app-insights-snapshot-debugger)

## Clone Sample Code and Deploy to azure

### Pre-requisites
* [Visual Studio 2017](https://www.visualstudio.com/)
    * Install ASP.NET and Web Development
    * To experience the full feature for Snapshot Debugging, you will need Visual Studio 2017 Enterprise. Check Snapshot Debugger in the Optional component list if you are installing Visual Studio Enterprise SKU
* Azure Subscription
    * [Getting started for free](https://azure.microsoft.com/free/?v=18.03)

### Setup the sample in your workspace
* Clone or download this repository
* Open *Profiler-Demo / Profiler-Demo.csproj* file
* Wait a few seconds for the project dependencies to restore

### Deploy the sample to Azure
* Right click on **Profiler-Demo** project, select **Publish ... **
* Without changing the default **Micrsoft Azure APp Service** and **Create New**, click **Publish** button
* Sign-in if needed in the **Create App Service** dialog
* Accept default generated App Name or edit to use your own Name
* Select your Subscription
* Select a resource group or create a new one by clicking the **New...** button
* For App Service Plan, click **New** button and select **Size** dropdown in the **Configure App Service Plan** dialog. Please choose **Basic** size tier or higher, and make sure the **RAM** is at least **3.5GB**. Click **OK** and exit this dialog
* Click **Create** in the **Create App Service** dialog and wait for publish process to finish
* The site should automatically open in your browser after publishing

![Website opens in browser](./media/Open-Browser.png)

## Add Application Insights to the App services
* Navigate to [Azure Portal](https://portal.azure.com)
* Go to your App Services Web App resource that hosts your Web Application
* on the left hand side navigation menu, search *Application Insights* and select **Application Insights** under Monitoring

![Enable Application Insights](./media/Monitor_Application_Insights.png)

* If you accept default option **Create new resource**, click **OK** button and follow instructions on the orange banner to restart your web Application

## Identify the root cause of runtime exceptions using Snapshot Debugger
Let's generate some exceptions in your web app to simulate when your app throws an exception in production environment.
This sample already includes the code that generate exceptions. All we have to do is to hit the web page where the exception is thrown.
* Navigate to your web app. Click on **Error** page

![Error](./media/Error.png)

* Refresh the page a few times
* Wait for a few minutes... (Grab a cup of coffee)
* Go to App Insights resource you created earlier. It should be in the same resource group as your Web App resource
* Go to Failures blade, click on **Exceptions** tab. Click **Exception** button under **Take action**


 ![Failure blade](./media/Failure.png)

 * In **Select a sample exception** the exception description should say *Index was outside the bounds of the array*. Click into one of them
 * You will see **Open debug snapshot** above Exceptions on the right side of the blade. Click that

![Open Debug Snapshot](./media/Open_Debug_Snapshot.png)

* You will see a blade saying **You don't have access**. This is because we made it a requirement for viewing snapshot to require a special permission, since the debug snapshot may contain sensitive information in local variables. Add yourself the permissions by click the button **Add Application Insights Snapshot Debugger Role**

![Snapshot Permissions](./media/Snapshot_Permission.png)

* Now you can see the Call Stack and Local variables of your application when an exception is thrown

![Analyze Snapshot](./media/Analyze_Snapshot.png)

* For a more advanced experience, click on **Download Snapshot** to open snapshot in Visual Studio. The download might take a few seconds. Grab some snacks while waiting :-)

* Double-click on the downloaded .diagsession file to open in Visual Studio. If prompted, click **Yes** to trust the source

![Trust Source](./media/Trust_Source.png)

* Click **Debug with Managed** among the debugging options. You will see how the exception was thrown in the code.

![Debug in Visual Studio](./media/Debug_VS.png)

## Identify the code that slowed down your application using Profiler
