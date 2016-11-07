import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Globals }  from '../../shared/globals';

import { POSTS } from './mock-posts';
import { Post } from './post.model';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class PostService {
  
  constructor(private globals: Globals, private http: Http) { }

  private postsUrl = this.globals.BASE_URL_API + 'posts?withChildren=false';

  getPosts() {
    return this.http
      .get(this.postsUrl)
      .toPromise()
      .then(response => {
        return response.json() as Post[];
      })
      .catch(this.handleError);
  }

  getPost(id: number): Promise<Post> {
    return this.getPosts()
      .then(posts => posts.find(post => post.id === id));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}