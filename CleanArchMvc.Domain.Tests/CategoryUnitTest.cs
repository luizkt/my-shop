using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id Value")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Empty Name")]
        public void CreateCategory_WithEmptyName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullyName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name, too short, minimum 3 characters");
        }
    }
}