using FluentValidation.TestHelper;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests;
public class InstitutionDTOValidatorTests
{
    [Theory]
    [MemberData(nameof(InvalidInstitutionTestData))]

    public async Task ShouldReturnValidationErrorIfAnyParameterIsNull(InstitutionInputDTO dto1, InstitutionInputDTO dto2, InstitutionInputDTO dto3, InstitutionInputDTO dto4)
    {
        var validator = new InstitutionDTOValidator();
        var result1 = await validator.TestValidateAsync(dto1);
        result1.ShouldHaveValidationErrorFor(user => user.State).WithErrorMessage("'State' must not be empty.");
        var result2 = await validator.TestValidateAsync(dto2);
        result2.ShouldHaveValidationErrorFor(user => user.City).WithErrorMessage("'City' must not be empty.");
        var result3 = await validator.TestValidateAsync(dto3);
        result3.ShouldHaveValidationErrorFor(user => user.Country).WithErrorMessage("'Country' must not be empty.");
        var result4 = await validator.TestValidateAsync(dto4);
        result4.ShouldHaveValidationErrorFor(user => user.Description).WithErrorMessage("'Description' must not be empty.");
    }
    [Fact]
    public async Task InstitutionWithDataShouldNotReturnValidationError()
    {
        var institution = new InstitutionInputDTO() { Description = "Instituto Federal Catarinense", Country = "Brasil", City = "Camboriú", State = "Santa Catarina" };
        var result = await new InstitutionDTOValidator().TestValidateAsync(institution);
        result.ShouldNotHaveAnyValidationErrors();
    }

    public static IEnumerable<object[]> InvalidInstitutionTestData()
    {
        yield return new object[]
        {
            new InstitutionInputDTO() {Description = "Instituto Federal Catarinense", Country = "Brasil", City= "Camboriú", State = ""},
            new InstitutionInputDTO() {Description = "Instituto Federal Catarinense", Country = "Brasil", City= "", State = "Santa Catarina"},
            new InstitutionInputDTO() {Description = "Instituto Federal Catarinense", Country = "", City= "Camboriú", State = "Santa Catarina"},
            new InstitutionInputDTO() {Description = "", Country = "Brasil", City= "Camboriú", State = "Santa Catarina"},
        };
    }

}
