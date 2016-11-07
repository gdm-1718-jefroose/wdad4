import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MaterializeModule } from 'angular2-materialize';

import './rxjs-extensions';
import { Globals } from './shared/globals';
import { AppComponent } from './app.component';
import { AppRoutingModule, routedComponents } from './app-routing.module';
import { LocationService } from './locations/shared/location.service';
import { LocationsComponent } from './locations/locations.component';
import { PostService } from './posts/shared/post.service';
import { PostsComponent } from './posts/posts.component';

@NgModule({
  declarations: [
    AppComponent,
    routedComponents,
    LocationsComponent,
    PostsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule,
    MaterializeModule
  ],
  providers: [
    Globals,
    LocationService,
    PostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
