import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NormalNavComponent } from './normal-nav.component';

describe('NormalNavComponent', () => {
  let component: NormalNavComponent;
  let fixture: ComponentFixture<NormalNavComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NormalNavComponent]
    });
    fixture = TestBed.createComponent(NormalNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
