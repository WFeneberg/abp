using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.PermissionManagement.Integration;

[RemoteService(Name = PermissionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(PermissionManagementRemoteServiceConsts.ModuleName)]
[ControllerName("PermissionIntegration")]
[Route("integration-api/permission-management/permissions")]
public class PermissionIntegrationController: AbpControllerBase, IPermissionIntegrationService
{
    protected IPermissionIntegrationService PermissionIntegrationService { get; }

    public PermissionIntegrationController(IPermissionIntegrationService permissionIntegrationService)
    {
        PermissionIntegrationService = permissionIntegrationService;
    }

    [HttpGet]
    [Route("is-granted")]
    public virtual Task<ListResultDto<PermissionGrantOutput>> IsGrantedAsync(List<PermissionGrantInput> input)
    {
        return PermissionIntegrationService.IsGrantedAsync(input);
    }
}
