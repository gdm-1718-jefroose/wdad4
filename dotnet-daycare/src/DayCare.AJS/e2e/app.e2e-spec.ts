import { DayCareAJSPage } from './app.po';

describe('day-care-ajs App', function() {
  let page: DayCareAJSPage;

  beforeEach(() => {
    page = new DayCareAJSPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
