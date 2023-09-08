import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { registerLicense } from '@syncfusion/ej2-base'
import { AppModule } from './app/app.module';


registerLicense("ORg4AjUWIQA/Gnt2V1hiQlRPd19dW3xLflF1VWFTfl96dlFWACFaRnZdQV1qSXhSckdhWXtccH1T")

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
