import { AfterContentInit, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TestService } from 'src/app/_services/test.service';
import { ITest } from '../../models/tests/test';
import { ITestCreate } from '../../models/tests/test-create';

@Component({
  selector: 'app-test-update',
  templateUrl: './test-update.component.html',
  styleUrls: ['./test-update.component.scss']
})
export class TestUpdateComponent implements AfterContentInit {

  public selectedTest: ITest;

  public creatorId: number;

  public courseId: number;

  updateTestForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private testService: TestService) { 
    this.updateTestForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
    });
  }

  ngAfterContentInit(): void {
    this.updateTestForm = this.formBuilder.group({
      name: [this.selectedTest?.name, [Validators.required, Validators.minLength(3)]],
    });
  }

  updateTest(): void {
    const test: ITestCreate = this.updateTestForm.getRawValue();
    test.courseId = this.courseId;
    test.creatorId = this.creatorId;

    this.testService.updateTest(test, this.selectedTest.id).subscribe((test) => {
      if (test) {
        this.snackBar.open("Test zaktualizowany.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Nie udało się zaktualizować testu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas aktualizacji testu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
