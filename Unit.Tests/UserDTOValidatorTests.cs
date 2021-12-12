using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Moq;
using ShareMyPaper.Application.Input.Dtos;
using ShareMyPaper.Application.Validators;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests;
public class UserDTOValidatorTests
{

    [Fact]
    public async Task ShouldReturnValidationErrorIfUserDocumentIsInvalid()
    {
        //Arrange
        var fileMock = new Mock<IFormFile>();
        var validator = new StudentDTOValidator();
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(5000001);
        fileMock.Setup(_ => _.ContentType).Returns("application/pdf");

        var userDTO = new StudentInputDTO()
        {
            UploadedFile = null,
            Email = "email@teste.com",
            InstitutionId = 1,
            Password = "teste@W@s123"

        };
        // Act
        var result = await validator.TestValidateAsync(userDTO);

        // Assert
        result.ShouldHaveValidationErrorFor(user => user.UploadedFile).WithErrorMessage("'Uploaded File' must not be empty.");
    }
}
