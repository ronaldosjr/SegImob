import {Attribute, Directive, forwardRef} from '@angular/core';
import {AbstractControl, NG_VALIDATORS, ValidationErrors, Validator} from '@angular/forms';

@Directive({
  selector: '[validateValue]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: forwardRef(() => ValidadeValueDirective), multi: true }
  ]
})
export class ValidadeValueDirective implements Validator {

  registerOnValidatorChange(fn: () => void): void {
  }

  validate(c: AbstractControl): { [key: string]: any } | null {
    if (!c.value || c.value <= 0 ) {
      return { 'isInvalidValue' : true };
    }
    return null;

  }

}
