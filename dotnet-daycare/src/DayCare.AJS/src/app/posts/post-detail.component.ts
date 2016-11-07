import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Post } from './shared/post.model';
import { PostService } from './shared/post.service';

@Component({
  selector: 'toh-post-detail',
  templateUrl: 'post-detail.component.html',
  styleUrls: ['post-detail.component.css']
})
export class PostDetailComponent implements OnInit {
  @Input() post: Post;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['id'] !== undefined) {
        let id = +params['id'];
        this.navigated = true;
        this.postService.getPost(id)
            .then(post => {
              this.post = post
            });
      } else {
        this.navigated = false;
        this.post = new Post();
      }
    });
  }
}