﻿using FluentValidation;
using OnionArchitect.Api.V1.Forms.Roles;


namespace OnionArchitect.Api.V1.Validators.RolesValidators
{
    public class CreateRoleFormValidator : AbstractValidator<CreateRoleForm>
    {
        public CreateRoleFormValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("نام نقش نمی تواند بدون مقدار یا رشته خالی باشد ");                
        }
    }
}
