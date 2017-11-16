import { TestBed, inject } from '@angular/core/testing';

import { VideoFilesService } from './video-files.service';

describe('VideoFilesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VideoFilesService]
    });
  });

  it('should be created', inject([VideoFilesService], (service: VideoFilesService) => {
    expect(service).toBeTruthy();
  }));
});
