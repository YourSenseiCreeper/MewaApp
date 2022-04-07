import { TestBed } from '@angular/core/testing';

import { MewaHttpService } from './mewa-http.service';

describe('MewaHttpService', () => {
  let service: MewaHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MewaHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
