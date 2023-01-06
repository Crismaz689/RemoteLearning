import { KeyValue } from '@angular/common';
import { OnInit, Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TestService } from 'src/app/_services/test.service';
import { ITest } from '../../models/tests/test';
import { ITextQuestion } from '../../models/text-questions/text-question';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  @Input()
  test: ITest;

  testForm: FormGroup;

  seconds: number = 100;
  
  constructor(private testService: TestService) { }

  async ngOnInit(): Promise<void> {
    await Promise.all(this.test.textQuestions.map(async (question, index) => {
      this.test.textQuestions[index] = await this.mixQuestions(question);
    }))
  }

  minutesLeft(): number {
    return parseInt((this.seconds / 60).toString());
  }

  secondsLeft(): number {
    return parseInt((this.seconds - (this.seconds / 60)).toString()); // naprawic
  }

  async mixQuestions(question: ITextQuestion): Promise<ITextQuestion> {
    var numbers: number[] = [];
    var collection: KeyValue<number, string>[] = [];
    collection.push({key: 0, value: question.correctAnswer});
    collection.push({key: 1, value: question.wrongAnswerA});
    collection.push({key: 2, value: question.wrongAnswerB});
    collection.push({key: 3, value: question.wrongAnswerC});

    while (numbers.length < 4) {
      const number = Math.floor(Math.random() * (4) + 1);

      if (!this.isRepeated(numbers, number)) {
        numbers.push(number);
      }
    }

    collection[0].value = collection[numbers[0]]?.value;
    collection[1].value = collection[numbers[1]]?.value;
    collection[2].value = collection[numbers[2]]?.value;
    collection[3].value = collection[numbers[3]]?.value;

    question.correctAnswer = collection[0].value;
    question.wrongAnswerA = collection[1].value;
    question.wrongAnswerB = collection[2].value;
    question.wrongAnswerC = collection[3].value;

    console.log(numbers);
    console.log(collection);
    console.log(question);
    return question;
  }

  isRepeated(numbers: number[], number: number): boolean {
    for(var i = 0; i < numbers.length; i++) {
      if (numbers[i] == number) return true;
    }

    return false;
  }

}
