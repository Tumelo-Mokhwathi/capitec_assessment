import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarkAsPaidModal } from './markAsPaid.component';

describe('Modal', () => {
  let component: MarkAsPaidModal;
  let fixture: ComponentFixture<MarkAsPaidModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MarkAsPaidModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarkAsPaidModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
