using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.IntegrationServices;
using System.Data.SqlClient;

namespace run_ssis_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetServerName = "localhost";
            string folderName = "Permanencia";
            string projectName = "Permanencia";
            string packageName = "Package1.dtsx";

            // Conexion
            string sqlConnectionString = "Data Source=" + targetServerName +
                ";Initial Catalog=master;Integrated Security=SSPI;";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            // Integration Services obj
            IntegrationServices integrationServices = new IntegrationServices(sqlConnection);

            // Integration Services catalog
            Catalog catalog = integrationServices.Catalogs["SSISDB"];

            // Carpeta
            CatalogFolder folder = catalog.Folders[folderName];

            // Proyecto
            ProjectInfo project = folder.Projects[projectName];

            // Package
            PackageInfo package = project.Packages[packageName];

            // Run run package
            package.Execute(false, null);

        }
    }
}
