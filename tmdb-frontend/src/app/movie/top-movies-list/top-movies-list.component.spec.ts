import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopMoviesListComponent } from './top-movies-list.component';

describe('TopMoviesListComponent', () => {
  let component: TopMoviesListComponent;
  let fixture: ComponentFixture<TopMoviesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopMoviesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TopMoviesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
