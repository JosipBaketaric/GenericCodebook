/**
 * Dictionary like in c#
 */

export class KeyValue<T> {
    constructor(key: any, value: T) {
        this.key = key;
        this.value = value;
    }

    key: any;
    value: T;
}

export class KeyValueDictionary<T> {
    _dict: KeyValue<T>[] = new Array<KeyValue<T>>();

    get length(): number {
        return this._dict.length;
    }
    // Methods
    addElement(key: any, value: T) {
        if (this._dict.filter(x => x.key == key).length > 0) {
            throw new Error('There is already an entry with same key!');
        }

        const tempKeyValue: KeyValue<T> = new KeyValue<T>(key, value);

        this._dict.push(tempKeyValue);
    }

    addElementKeyValue(element: KeyValue<T>) {
        if (element == null) {
            throw new Error('Element null');
        }
        this.addElement(element.key, element.value);
    }

    getElementByKey(key: any): KeyValue<T> {
        const element = this._dict.filter(x => x.key === key);

        if (element.length === 0) {
            throw new Error('There are no elements in dictionary with key: ' + key);
        }

        if (element.length > 1) {
            throw new Error('There are multiple elements in dictionary with key: ' + key);
        }
        return element[0];
    }

    getElementByIndex(index: number): KeyValue<T> {
        if (index < 0) {
            throw new Error('Index must be positive number');
        }

        if (index > this._dict.length) {
            throw new Error('Index out of range');
        }
        return this._dict[index];
    }

    removeElementByIndex(index: number) {
        if (index < 0) {
            throw new Error('Index must be positive number');
        }

        if (index > this._dict.length) {
            throw new Error('Index out of range');
        }

        this._dict.splice(index, 1);
    }

    getIndex(element: KeyValue<T>): number {
        const index = this._dict.indexOf(element);
        if (index === -1) {
            throw new Error('Element does not exist in dictionary');
        }
        return index;
    }

    removeElementByKey(key: any) {
        const element = this.getElementByKey(key);
        const index = this.getIndex(element);
        this.removeElementByIndex(index);
    }

    clear() {
        this._dict.splice(0, this._dict.length);
    }

    containsKey(key: any): boolean {
        const element = this._dict.filter(x => x.key === key);
        if (element.length === 0) {
            return false;
        }
        return true;
    }

    toString() {
        let stringRepresentation = '';

        for (const entry of this._dict) {
            stringRepresentation += entry.key.toString() + ': ' + entry.value.toString() + ',\n';
        }
        return stringRepresentation;
    }

    copyDictionary(): KeyValueDictionary<T> {
        const newDict: KeyValueDictionary<T> = new KeyValueDictionary<T>();

        for (let i = 0; i < this._dict.length; i++) {
            const item = this._dict[i];
            newDict.addElement(item.key, item.value);
        }
        return newDict;
    }

    copyKeyValueArray(): KeyValue<T>[] {
        const newKeyValue: KeyValue<T>[] = new Array<KeyValue<T>>();

        for (let i = 0; i < this._dict.length; i++) {
            const item = this._dict[i];
            newKeyValue.push(item);
        }
        return newKeyValue;
    }

    addRange(items: KeyValue<T>[]) {
        if (items === null) {
            throw new Error('Null reference in addRange');
        }

        for (const item of items) {
            this.addElementKeyValue(item);
        }
    }

    tryGetValue(key: any) {
        const element = this._dict.filter(x => x.key === key);
        if (element.length === 0) {
            return null;
        }

        if (element.length > 1) {
            return null;
        }
        return element[0];
    }
    // J-LINQ

    where(callbackfn: (this: void, value: KeyValue<T>, index: number, array: KeyValue<T>[]) => any): KeyValueDictionary<T> {
        const newDict: KeyValueDictionary<T> = new KeyValueDictionary<T>();

        for (let i = 0; i < this._dict.length; i++) {
            const item = this._dict[i];
            const result = callbackfn(item, i, this._dict);
            if (result === true) {
                newDict.addElementKeyValue(item);
            }
        }
        return newDict;
    }

    any(callbackfn: (this: void, value: KeyValue<T>, index: number, array: KeyValue<T>[]) => any): boolean {
        for (let i = 0; i < this._dict.length; i++) {
            const item = this._dict[i];
            const result = callbackfn(item, i, this._dict);
            if (result === true) {
                return true;
            }
        }
        return false;
    }

    all(callbackfn: (this: void, value: KeyValue<T>, index: number, array: KeyValue<T>[]) => any): boolean {
        for (let i = 0; i < this._dict.length; i++) {
            const item = this._dict[i];
            const result = callbackfn(item, i, this._dict);
            if (result === false) {
                return false;
            }
        }
        return true;
    }

    take(count: number): KeyValueDictionary<T> {
        const newDict: KeyValueDictionary<T> = new KeyValueDictionary<T>();

        if (this._dict.length < count) {
            throw Error('Dictionary has les elements than parameter in take function');

        }

        for (let i = 0; i < count; i++) {
            const item = this._dict[i];
            newDict.addElementKeyValue(item);
        }
        return newDict;
    }

    skip(count: number): KeyValueDictionary<T> {
        const newDict: KeyValueDictionary<T> = new KeyValueDictionary<T>();

        if (this._dict.length < count) {
            throw Error('Dictionary has les elements than parameter in skip function');
        }

        for (let i = count; i < this._dict.length; i++) {
            const item = this._dict[i];
            newDict.addElementKeyValue(item);
        }
        return newDict;
    }

    firstOrDefault() {
        return this._dict[0];
    }


}
