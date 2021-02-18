import { TestBed } from '@angular/core/testing';

import { BandasService } from './bandas.service';

describe('BandasService', () => {
  let service: BandasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BandasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
