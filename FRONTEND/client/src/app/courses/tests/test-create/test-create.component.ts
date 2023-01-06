import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TestService } from 'src/app/_services/test.service';
import { ITestCreate } from '../../models/tests/test-create';

@Component({
  selector: 'app-test-create',
  templateUrl: './test-create.component.html',
  styleUrls: ['./test-create.component.scss']
})
export class TestCreateComponent implements OnInit {

  public creatorId: number;

  public courseId: number;

  createTestForm: FormGroup;

  constructor(private testService: TestService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar) {
    this.createTestForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
    });
   }

  ngOnInit(): void {
    document.getElementById("testName")?.focus();
  }

  createTest(): void {
    const newTest: ITestCreate = this.createTestForm.getRawValue();
    newTest.courseId = this.courseId;
    newTest.creatorId = this.creatorId;

    this.testService.createTest(newTest).subscribe((test) => {
      if (test) {
        this.snackBar.open("Test został utworzony.", '', { panelClass: ['text-white', 'bg-success'] }); 
      }
      else {
        this.snackBar.open("Nie udało się utworzyć testu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas tworzenia testu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
