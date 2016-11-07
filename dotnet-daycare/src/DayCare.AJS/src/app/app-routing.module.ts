import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PostsComponent } from './posts/posts.component';
import { PostDetailComponent } from './posts/post-detail.component';
import { LocationsComponent } from './locations/locations.component';
import { LocationDetailComponent } from './locations/location-detail.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/posts',
    pathMatch: 'full'
  },
  {
    path: 'posts',
    component: PostsComponent
  },
  {
    path: 'posts/:id',
    component: PostDetailComponent
  },
  {
    path: 'locations',
    component: LocationsComponent
  },
  {
    path: 'locations/:id',
    component: LocationDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routedComponents = [LocationsComponent, LocationDetailComponent, PostsComponent, PostDetailComponent];