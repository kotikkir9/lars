import { TestBed } from '@angular/core/testing';

import { UddannelseService } from './uddannelse.service';

describe('UddannelseService', () => {
  let service: UddannelseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UddannelseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
