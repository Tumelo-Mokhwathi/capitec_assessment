import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveModal } from './modal.component';

describe('Modal', () => {
  let component: RemoveModal;
  let fixture: ComponentFixture<RemoveModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoveModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemoveModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
