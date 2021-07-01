using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1.00m, 1, "Product Image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Id Value")]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description.Description is required");
        }

        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 1.0m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description.Description is required");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description.Description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_WithNegativePrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1.00m, 1, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price.Price value");
        }

        [Theory(DisplayName = "Create Product With Negative Stock")]
        [InlineData(-5)]
        public void CreateProduct_WithNegativeStock_DomainExceptionInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1.00m, value, "Product Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock.Stock value");
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImage_NullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1.00m, 1, null);
            action.Should().NotThrow<System.NullReferenceException>();
        }
    }
}