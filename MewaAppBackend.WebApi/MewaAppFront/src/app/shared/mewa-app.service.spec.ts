import { TestBed } from '@angular/core/testing';

import { MewaAppService } from './mewa-app.service';

describe('MewaAppService', () => {
  let service: MewaAppService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MewaAppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
