import { Component } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <main style="font-family: Arial, sans-serif; max-width: 760px; margin: 3rem auto;">
      <h1>Dependency Security Sample</h1>
      <p>This minimal Angular UI is deliberately outside the Visual Studio solution.</p>
      <p>Use this folder to verify that the Playbook discovers npm manifests independently.</p>
    </main>
  `
})
class AppComponent {}

bootstrapApplication(AppComponent).catch((error) => console.error(error));
