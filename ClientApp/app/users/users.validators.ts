import { FormControl } from "@angular/forms";
import { FormGroup } from "@angular/forms/src/model";

export class UsersValidators
{
    static emailRequired(control: FormControl)
    {
        var value : string = control.value;
        var emailRegex = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;

        if(!emailRegex.test(value))
            return { emailRequired: true};

        return null;
    }

    static isPasswordsMath(group : FormGroup)
    {
        var valid = true;
        var currentValue = null;
        for(var name in group.controls)
        {
            var val = group.controls[name].value
            
            if(!currentValue)
            {
                currentValue = val;
                continue;
            }

            valid = currentValue == val;
                
        }
        return valid ? null : { passwordsDontMatch : true};
    }
}