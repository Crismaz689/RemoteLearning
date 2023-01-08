namespace RemoteLearning.Infrastructure.Services;

public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<TestDto> CreateTest(CreateTestDto testDto, string userId)
    {
        var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));
        if (testDto != null && (await DoesUserHasPermission(testDto.CourseId, userId) || user.RoleId == 1))
        {
            var test = _mapper.Map<Test>(testDto);

            await _unitOfWork.Tests.Create(test);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TestDto>(test);
            }
        }
        else
        {
            throw new TestNoPermissionException("You have no access to this operation.");
        }

        return null;
    }

    public async Task<bool> DeleteTest(long testId, string userId)
    {
        var test = await _unitOfWork.Tests.GetById(testId);


        if (test == null)
        {
            return false;
        }
        else
        {
            var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));
            if (await DoesUserHasPermission(test.CourseId, userId) || user.RoleId == 1)
            {
                await _unitOfWork.Tests.Delete(testId);

                return await _unitOfWork.SaveChangesAsync() != 0;
            }
            else
            {
                throw new TestNoPermissionException("You have no access to this operation.");
            }
        }

        return false;
    }

    public async Task<TestDto> GetTestById(long testId, string userId)
    {
        var user = await _unitOfWork.Users.GetTestPermission(Convert.ToInt64(userId), testId);
        var test = await _unitOfWork.Tests.GetById(testId);

        if (test != null && user != null)
        {
            return _mapper.Map<TestDto>(test);
        }
        else
        {
            return null;
        }
    }

    public async Task<TestForStudentDto> GetTestByStudent(long testId, string userId)
    {
        var user = await _unitOfWork.Users.GetTestPermission(Convert.ToInt64(userId), testId);
        var test = await _unitOfWork.Tests.GetWithQuestions(testId);

        if (test != null && user != null)
        {
            List<TextQuestionForStudentDto> textQuestions = new List<TextQuestionForStudentDto>();

            test.TextQuestions.ToList().ForEach((questions) =>
            {
                var answers = new string[4];
                answers[0] = questions.CorrectAnswer;
                answers[1] = questions.WrongAnswerA;
                answers[2] = questions.WrongAnswerB;
                answers[3] = questions.WrongAnswerC;

                textQuestions.Add(new TextQuestionForStudentDto()
                {
                    Id = questions.Id,
                    Title = questions.Title,
                    Answers = answers
                });
            });
            TestForStudentDto returnTest = new TestForStudentDto()
            {
                Id = test.Id,
                TextQuestions = textQuestions
            };

            returnTest = MixupQuestions(returnTest);

            return returnTest;
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<TestAdminDto>> GetAllTestsByAdmin()
    {
        var tests = await _unitOfWork.Tests.GetAllTestsByAdmin();

        if (tests != null && tests.Any())
        {
            return _mapper.Map<IEnumerable<TestAdminDto>>(tests);
        }

        return Enumerable.Empty<TestAdminDto>();
    }

    public async Task<TestDto> UpdateTest(CreateTestDto testDto, long id, string userId)
    {
        var test = await _unitOfWork.Tests.GetById(id);
        var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));

        if (testDto != null && test != null && (await DoesUserHasPermission(testDto.CourseId, userId) || user.RoleId == 1))
        {
            test.Name = testDto.Name;

            await _unitOfWork.Tests.Update(test);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TestDto>(test);
            }
        }
        else
        {
            throw new TestNoPermissionException("You have no access to this operation.");
        }

        return null;
    }

    public async Task<bool> WasTestTaken(long testId, string userId)
    {
        var testResults = await _unitOfWork.UserTestResults.GetResults(testId, Convert.ToInt64(userId));

        return testResults != null;
    }

    public async Task<bool> ConfirmTest(TestFinishedDto dto, string userId)
    {
        var test = await _unitOfWork.Tests.GetWithQuestions(dto.TestId);
        decimal points = 0M;

        dto.Answers.ToList().ForEach((answer) =>
        {
            var question = test.TextQuestions.FirstOrDefault(tq => tq.Id == answer.Id);

            if (question.CorrectAnswer.ToLower().Equals(answer.Answer.ToLower()))
            {
                points += question.Points;
            }
        });

        var testResults = new UserTestResult()
        {
            UserId = Convert.ToInt64(userId),
            TestId = dto.TestId,
            Points = points,
            TotalPoints = test.Points
        };

        await _unitOfWork.UserTestResults.Create(testResults);

        return await _unitOfWork.SaveChangesAsync() != 0;
    }

    private async Task<bool> DoesUserHasPermission(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;

    private TestForStudentDto MixupQuestions(TestForStudentDto test)
    {
        Random rnd = new Random();

        test.TextQuestions.ToList().ForEach((questions) =>
        {
            var dict = new Dictionary<int, string>();
            var numbers = new List<int>();

            dict.Add(0, questions.Answers[0]);
            dict.Add(1, questions.Answers[1]);
            dict.Add(2, questions.Answers[2]);
            dict.Add(3, questions.Answers[3]);

            while (numbers.Count < 4)
            {
                var number = rnd.Next(0, 4);

                if (!IsNumberRepeated(numbers, number))
                {
                    numbers.Add(number);
                }
            }

            questions.Answers[0] = dict[numbers[0]];
            questions.Answers[1] = dict[numbers[1]];
            questions.Answers[2] = dict[numbers[2]];
            questions.Answers[3] = dict[numbers[3]];
        });

        return test;
    }

    private bool IsNumberRepeated(List<int> numbers, int number) => numbers.Contains(number);


}
