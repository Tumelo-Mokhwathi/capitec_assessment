import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateModal } from './modal.component';

describe('Modal', () => {
  let component: UpdateModal;
  let fixture: ComponentFixture<UpdateModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
