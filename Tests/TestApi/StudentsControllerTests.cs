//using AtlanticProductClient.API.Controllers;
//using AtlanticProductClient.API.Dtos.Student;
//using AtlanticProductClient.Application.Features.Students.Commands.CreateStudent;
//using AtlanticProductClient.Application.Features.Students.Commands.DeleteStudent;
//using AtlanticProductClient.Application.Features.Students.Commands.UpdateStudent;
//using AtlanticProductClient.Application.Features.Students.Queries.GetStudentById;
//using AtlanticProductClient.Application.Features.Students.Queries.GetStudentsList;
//using AutoMapper;
//using MediatR;
//using Moq;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;
//using AtlanticProductClient.Domain.Entities;

//namespace  AtlanticProductClient.Tests.Controllers
//{
//    public class StudentsControllerTests
//    {
//        private readonly Mock<IMediator> _mediatorMock;
//        private readonly Mock<IMapper> _mapperMock;
//        private readonly StudentsController _controller;

//        public StudentsControllerTests()
//        {
//            _mediatorMock = new Mock<IMediator>();
//            _mapperMock = new Mock<IMapper>();
//            _controller = new StudentsController(_mediatorMock.Object, _mapperMock.Object);
//        }

//        [Fact]
//        public async Task Create_ReturnsOkResult_WithStudentId()
//        {
//            // Arrange
//            var studentForCreationDto = new StudentForCreationDto { Name = "John", LastName = "Doe" };
//            var createStudentCommand = new CreateStudentCommand { Name = "John", LastName = "Doe" };
//            _mapperMock.Setup(m => m.Map<CreateStudentCommand>(It.IsAny<StudentForCreationDto>())).Returns(createStudentCommand);
//            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1L);

//            // Act
//            var result = await _controller.Create(studentForCreationDto);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var studentId = Assert.IsType<long>(okResult.Value);
//            Assert.Equal(1L, studentId);
//        }

//        [Fact]
//        public async Task Update_ReturnsOkResult()
//        {
//            // Arrange
//            var studentForUpdateDto = new StudentForUpdateDto { Name = "John", LastName = "Doe" };
//            var updateStudentCommand = new UpdateStudentCommand { Id = 1, Name = "John", LastName = "Doe" };
//            _mapperMock.Setup(m => m.Map<UpdateStudentCommand>(It.IsAny<StudentForUpdateDto>())).Returns(updateStudentCommand);
//            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateStudentCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

//            // Act
//            var result = await _controller.Update(1, studentForUpdateDto);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public async Task Delete_ReturnsOkResult()
//        {
//            // Arrange
//            var deleteStudentCommand = new DeleteStudentCommand { Id = 1 };
//            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

//            // Act
//            var result = await _controller.Delete(1);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//public async Task GetById_ReturnsOkResult_WithStudentDto()
//{
//    // Arrange
//    var student = new StudentDto { Id = 1, Name = "John", LastName = "Doe" };
//    _mediatorMock.Setup(m => m.Send(It.IsAny<GetStudentByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Student { Id = 1, Name = "John", LastName = "Doe" });
//    _mapperMock.Setup(m => m.Map<StudentDto>(It.IsAny<Student>())).Returns(student);

//    // Act
//    var result = await _controller.GetById(1);

//    // Assert
//    var okResult = Assert.IsType<OkObjectResult>(result);
//    var studentDto = Assert.IsType<StudentDto>(okResult.Value);
//    Assert.Equal(1, studentDto.Id);
//}

//[Fact]
//public async Task List_ReturnsOkResult_WithListOfStudentDtos()
//{
//    // Arrange
//    var students = new List<Student> { new Student { Id = 1, Name = "John", LastName = "Doe" } };
//    var studentDtos = new List<StudentDto> { new StudentDto { Id = 1, Name = "John", LastName = "Doe" } };
//    _mediatorMock.Setup(m => m.Send(It.IsAny<GetStudentsListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(students);
//    _mapperMock.Setup(m => m.Map<IEnumerable<StudentDto>>(It.IsAny<IEnumerable<Student>>())).Returns(studentDtos);

//    // Act
//    var result = await _controller.List();

//    // Assert
//    var okResult = Assert.IsType<OkObjectResult>(result);
//    var returnedStudentDtos = Assert.IsType<List<StudentDto>>(okResult.Value);
//    Assert.Single(returnedStudentDtos);
//}
//}
//}