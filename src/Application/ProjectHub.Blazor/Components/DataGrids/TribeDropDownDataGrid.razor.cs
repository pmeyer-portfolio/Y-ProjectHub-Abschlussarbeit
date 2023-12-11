﻿namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public partial class TribeDropDownDataGrid
{
    private Response<IList<TribeViewDto>> response = new() { Success = true };

    [Inject]
    public required ITribeService Service { get; set; }

    [Parameter]
    public EventCallback<int> OnItemSelected { get; set; }

    public IList<TribeViewDto>? Tribes { get; set; }

    protected override async Task OnInitializedAsync() { await this.Initialize(); }

    private void OnValueChanged(object value)
    {
        if (value is int intValue)
        {
            this.OnItemSelected.InvokeAsync(intValue);
        }
    }

    private async Task Initialize()
    {
        this.response = await this.Service.GetAll();
        {
            if (this.response.Success)
            {
                this.Tribes = this.response.Data;
                this.Tribes?.Insert(0, new TribeViewDto
                {
                    Id   = -1,
                    Name = "No assignment"
                });
            }
        }
    }
}