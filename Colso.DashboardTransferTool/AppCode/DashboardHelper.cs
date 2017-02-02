using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colso.DashboardTransferTool.AppCode
{
    /// <summary>
    /// Helps to interact with Crm dashboards
    /// </summary>
    internal class DashboardHelper
    {
        /// <summary>
        /// Retrieve the list of dashboards
        /// </summary>
        /// <param name="service">Organization Service</param>
        /// <returns>List of dashboards</returns>
        public static List<Entity> RetrieveDashboards(IOrganizationService service)
        {
            try
            {
                var results = service.RetrieveMultiple(new QueryExpression("systemform")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("objecttypecode", ConditionOperator.Equal, "none"),
                            new ConditionExpression("type", ConditionOperator.Equal, 0)
                        }
                    }
                });

                return results.Entities.ToList();
            }
            catch (Exception error)
            {
                string errorMessage = CrmExceptionHelper.GetErrorMessage(error, false);
                throw new Exception("Error while retrieving dashboards: " + errorMessage);
            }
        }

        public static List<Entity> RetrieveUserDashboards(IOrganizationService service)
        {
            try
            {
                var results = service.RetrieveMultiple(new QueryExpression("userform")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("objecttypecode", ConditionOperator.Equal, "none"),
                            new ConditionExpression("type", ConditionOperator.Equal, 0)
                        }
                    }
                });

                return results.Entities.ToList();
            }
            catch (Exception error)
            {
                string errorMessage = CrmExceptionHelper.GetErrorMessage(error, false);
                throw new Exception("Error while retrieving user dashboards: " + errorMessage);
            }
        }
    }
}