// Type definitions for React v0.13.1 (external module)
// Project: http://facebook.github.io/react/
// Definitions by: Asana <https://asana.com>, AssureSign <http://www.assuresign.com>
// Definitions: https://github.com/borisyankov/DefinitelyTyped

declare module React {
    //
    // React Elements
    // ----------------------------------------------------------------------


    interface ReactElement<P> {
        type: any;
        props: P;
        key: string;
        ref: string;
    }

    interface ClassicElement<P> extends ReactElement<P> {
        type: any;
        ref: string;
    }

    interface DOMElement<P> extends ClassicElement<P> {
        type: string;
        ref: string;
    }


    //
    // Factories
    // ----------------------------------------------------------------------

    interface Factory<P> {
        (props?: P, ...children: any[]): ReactElement<P>;
    }

    interface ClassicFactory<P> extends Factory<P> {
        (props?: P, ...children: any[]): ClassicElement<P>;
    }

    interface DOMFactory<P> extends ClassicFactory<P> {
        (props?: P, ...children: any[]): DOMElement<P>;
    }

    //
    // Top Level API
    // ----------------------------------------------------------------------

    function createClass<P, S>(spec: ComponentSpec<P, S>): ClassicComponentClass<P>;

    function createFactory<P>(type: string): DOMFactory<P>;
    function createFactory<P>(type: ClassicComponentClass<P>): ClassicFactory<P>;
    function createFactory<P>(type: ComponentClass<P>): Factory<P>;

    function createElement<P>(
        type: string,
        props?: P,
        ...children: any[]): DOMElement<P>;
    function createElement<P>(
        type: ClassicComponentClass<P>,
        props?: P,
        ...children: any[]): ClassicElement<P>;
    function createElement<P>(
        type: ComponentClass<P>,
        props?: P,
        ...children: any[]): ReactElement<P>;

    function cloneElement<P>(
        element: DOMElement<P>,
        props?: P,
        ...children: any[]): DOMElement<P>;
    function cloneElement<P>(
        element: ClassicElement<P>,
        props?: P,
        ...children: any[]): ClassicElement<P>;
    function cloneElement<P>(
        element: ReactElement<P>,
        props?: P,
        ...children: any[]): ReactElement<P>;

    function render<P>(
        element: DOMElement<P>,
        container: Element,
        callback?: () => any): DOMComponent<P>;
    function render<P, S>(
        element: ClassicElement<P>,
        container: Element,
        callback?: () => any): ClassicComponent<P, S>;
    function render<P, S>(
        element: ReactElement<P>,
        container: Element,
        callback?: () => any): Component<P, S>;

    function unmountComponentAtNode(container: Element): boolean;
    function renderToString(element: ReactElement<any>): string;
    function renderToStaticMarkup(element: ReactElement<any>): string;
    function isValidElement(object: {}): boolean;
    function initializeTouchEvents(shouldUseTouch: boolean): void;

    function findDOMNode<TElement extends Element>(component: Component<any, any>): TElement;
    function findDOMNode<TElement extends Element>(element: Element): TElement;
    function findDOMNode(component: Component<any, any>): Element;
    function findDOMNode(element: Element): Element;

    var DOM: ReactDOM;
    var PropTypes: ReactPropTypes;
    var Children: anyren;

    //
    // Component API
    // ----------------------------------------------------------------------

    // Base component for plain JS classes
    class Component<P, S> implements ComponentLifecycle<P, S> {
        constructor(props?: P, context?: any);
        setState(f: (prevState: S, props: P) => S, callback?: () => any): void;
        setState(state: S, callback?: () => any): void;
        forceUpdate(): void;
        props: P;
        state: S;
        context: any;
        refs: {
            [key: string]: Component<any, any>
        };
    }

    interface ClassicComponent<P, S> extends Component<P, S> {
        replaceState(nextState: S, callback?: () => any): void;
        getDOMNode<TElement extends Element>(): TElement;
        getDOMNode(): Element;
        isMounted(): boolean;
        getInitialState?(): S;
        setProps(nextProps: P, callback?: () => any): void;
        replaceProps(nextProps: P, callback?: () => any): void;
    }

    interface DOMComponent<P> extends ClassicComponent<P, any> {
        tagName: string;
    }

    interface ChildContextProvider<CC> {
        getChildContext(): CC;
    }

    //
    // Class Interfaces
    // ----------------------------------------------------------------------

    interface ComponentClass<P> {
        new(props?: P, context?: any): Component<P, any>;
        propTypes?: ValidationMap<P>;
        contextTypes?: ValidationMap<any>;
        childContextTypes?: ValidationMap<any>;
        defaultProps?: P;
    }

    interface ClassicComponentClass<P> extends ComponentClass<P> {
        new(props?: P, context?: any): ClassicComponent<P, any>;
        getDefaultProps?(): P;
        displayName?: string;
    }

    //
    // Component Specs and Lifecycle
    // ----------------------------------------------------------------------

    interface ComponentLifecycle<P, S> {
        componentWillMount?(): void;
        componentDidMount?(): void;
        componentWillReceiveProps?(nextProps: P, nextContext: any): void;
        shouldComponentUpdate?(nextProps: P, nextState: S, nextContext: any): boolean;
        componentWillUpdate?(nextProps: P, nextState: S, nextContext: any): void;
        componentDidUpdate?(prevProps: P, prevState: S, prevContext: any): void;
        componentWillUnmount?(): void;
    }

    interface Mixin<P, S> extends ComponentLifecycle<P, S> {
        mixins?: Mixin<P, S>;
        statics?: {
            [key: string]: any;
        };

        displayName?: string;
        propTypes?: ValidationMap<any>;
        contextTypes?: ValidationMap<any>;
        childContextTypes?: ValidationMap<any>

        getDefaultProps?(): P;
        getInitialState?(): S;
    }

    interface ComponentSpec<P, S> extends Mixin<P, S> {
        render(): ReactElement<any>;
    }

    //
    // Event System
    // ----------------------------------------------------------------------

    interface SyntheticEvent {
        bubbles: boolean;
        cancelable: boolean;
        currentTarget: EventTarget;
        defaultPrevented: boolean;
        eventPhase: number;
        isTrusted: boolean;
        nativeEvent: Event;
        preventDefault(): void;
        stopPropagation(): void;
        target: EventTarget;
        timeStamp: Date;
        type: string;
    }

    interface DragEvent extends SyntheticEvent {
        dataTransfer: DataTransfer;
    }

    interface ClipboardEvent extends SyntheticEvent {
        clipboardData: DataTransfer;
    }

    interface KeyboardEvent extends SyntheticEvent {
        altKey: boolean;
        charCode: number;
        ctrlKey: boolean;
        getModifierState(key: string): boolean;
        key: string;
        keyCode: number;
        locale: string;
        location: number;
        metaKey: boolean;
        repeat: boolean;
        shiftKey: boolean;
        which: number;
    }

    interface FocusEvent extends SyntheticEvent {
        relatedTarget: EventTarget;
    }

    interface FormEvent extends SyntheticEvent {
    }

    interface MouseEvent extends SyntheticEvent {
        altKey: boolean;
        button: number;
        buttons: number;
        clientX: number;
        clientY: number;
        ctrlKey: boolean;
        getModifierState(key: string): boolean;
        metaKey: boolean;
        pageX: number;
        pageY: number;
        relatedTarget: EventTarget;
        screenX: number;
        screenY: number;
        shiftKey: boolean;
    }

    interface TouchEvent extends SyntheticEvent {
        altKey: boolean;
        changedTouches: TouchList;
        ctrlKey: boolean;
        getModifierState(key: string): boolean;
        metaKey: boolean;
        shiftKey: boolean;
        targetTouches: TouchList;
        touches: TouchList;
    }

    interface UIEvent extends SyntheticEvent {
        detail: number;
        view: AbstractView;
    }

    interface WheelEvent extends SyntheticEvent {
        deltaMode: number;
        deltaX: number;
        deltaY: number;
        deltaZ: number;
    }

    //
    // Event Handler Types
    // ----------------------------------------------------------------------

    interface EventHandler<E extends SyntheticEvent> {
        (event: E): void;
    }

    interface DragEventHandler extends EventHandler<DragEvent> {}
    interface ClipboardEventHandler extends EventHandler<ClipboardEvent> {}
    interface KeyboardEventHandler extends EventHandler<KeyboardEvent> {}
    interface FocusEventHandler extends EventHandler<FocusEvent> {}
    interface FormEventHandler extends EventHandler<FormEvent> {}
    interface MouseEventHandler extends EventHandler<MouseEvent> {}
    interface TouchEventHandler extends EventHandler<TouchEvent> {}
    interface UIEventHandler extends EventHandler<UIEvent> {}
    interface WheelEventHandler extends EventHandler<WheelEvent> {}

    //
    // Props / DOM Attributes
    // ----------------------------------------------------------------------

    interface Props<T> {
        children?: any;
        key?: string;
        ref?: string;
    }

    interface DOMAttributes extends Props<DOMComponent<any>> {
        onCopy?: ClipboardEventHandler;
        onCut?: ClipboardEventHandler;
        onPaste?: ClipboardEventHandler;
        onKeyDown?: KeyboardEventHandler;
        onKeyPress?: KeyboardEventHandler;
        onKeyUp?: KeyboardEventHandler;
        onFocus?: FocusEventHandler;
        onBlur?: FocusEventHandler;
        onChange?: FormEventHandler;
        onInput?: FormEventHandler;
        onSubmit?: FormEventHandler;
        onClick?: MouseEventHandler;
        onDoubleClick?: MouseEventHandler;
        onDrag?: DragEventHandler;
        onDragEnd?: DragEventHandler;
        onDragEnter?: DragEventHandler;
        onDragExit?: DragEventHandler;
        onDragLeave?: DragEventHandler;
        onDragOver?: DragEventHandler;
        onDragStart?: DragEventHandler;
        onDrop?: DragEventHandler;
        onMouseDown?: MouseEventHandler;
        onMouseEnter?: MouseEventHandler;
        onMouseLeave?: MouseEventHandler;
        onMouseMove?: MouseEventHandler;
        onMouseOut?: MouseEventHandler;
        onMouseOver?: MouseEventHandler;
        onMouseUp?: MouseEventHandler;
        onTouchCancel?: TouchEventHandler;
        onTouchEnd?: TouchEventHandler;
        onTouchMove?: TouchEventHandler;
        onTouchStart?: TouchEventHandler;
        onScroll?: UIEventHandler;
        onWheel?: WheelEventHandler;

        dangerouslySetInnerHTML?: {
            __html: string;
        };
    }

    // This interface is not complete. Only properties accepting
    // unitless numbers are listed here (see CSSProperty.js in React)
    interface CSSProperties {
        boxFlex?: number;
        boxFlexGroup?: number;
        columnCount?: number;
        flex?: number;
        flexGrow?: number;
        flexShrink?: number;
        fontWeight?: number;
        lineClamp?: number;
        lineHeight?: number;
        opacity?: number;
        order?: number;
        orphans?: number;
        widows?: number;
        zIndex?: number;
        zoom?: number;

        // SVG-related properties
        fillOpacity?: number;
        strokeOpacity?: number;
        strokeWidth?: number;
    }

    interface HTMLAttributes extends DOMAttributes {
        ref?: string ;

        accept?: string;
        acceptCharset?: string;
        accessKey?: string;
        action?: string;
        allowFullScreen?: boolean;
        allowTransparency?: boolean;
        alt?: string;
        async?: boolean;
        autoComplete?: boolean;
        autoFocus?: boolean;
        autoPlay?: boolean;
        cellPadding?: number;
        cellSpacing?: number;
        charSet?: string;
        checked?: boolean;
        classID?: string;
        className?: string;
        cols?: number;
        colSpan?: number;
        content?: string;
        contentEditable?: boolean;
        contextMenu?: string;
        controls?: any;
        coords?: string;
        crossOrigin?: string;
        data?: string;
        dateTime?: string;
        defer?: boolean;
        dir?: string;
        disabled?: boolean;
        download?: any;
        draggable?: boolean;
        encType?: string;
        form?: string;
        formNoValidate?: boolean;
        frameBorder?: number;
        height?: number;
        hidden?: boolean;
        href?: string;
        hrefLang?: string;
        htmlFor?: string;
        httpEquiv?: string;
        icon?: string;
        id?: string;
        label?: string;
        lang?: string;
        list?: string;
        loop?: boolean;
        manifest?: string;
        max?: number;
        maxLength?: number;
        media?: string;
        mediaGroup?: string;
        method?: string;
        min?: number;
        multiple?: boolean;
        muted?: boolean;
        name?: string;
        noValidate?: boolean;
        open?: boolean;
        pattern?: string;
        placeholder?: string;
        poster?: string;
        preload?: string;
        radioGroup?: string;
        readOnly?: boolean;
        rel?: string;
        required?: boolean;
        role?: string;
        rows?: number;
        rowSpan?: number;
        sandbox?: string;
        scope?: string;
        scrollLeft?: number;
        scrolling?: string;
        scrollTop?: number;
        seamless?: boolean;
        selected?: boolean;
        shape?: string;
        size?: number;
        sizes?: string;
        span?: number;
        spellCheck?: boolean;
        src?: string;
        srcDoc?: string;
        srcSet?: string;
        start?: number;
        step?: number;
        style?: CSSProperties;
        tabIndex?: number;
        target?: string;
        title?: string;
        type?: string;
        useMap?: string;
        value?: string;
        width?: number;
        wmode?: string;

        // Non-standard Attributes
        autoCapitalize?: boolean;
        autoCorrect?: boolean;
        property?: string;
        itemProp?: string;
        itemScope?: boolean;
        itemType?: string;
    }

    interface SVGAttributes extends DOMAttributes {
        ref?: string;

        cx?: number;
        cy?: number;
        d?: string;
        dx?: number;
        dy?: number;
        fill?: string;
        fillOpacity?: number;
        fontFamily?: string;
        fontSize?: number;
        fx?: number;
        fy?: number;
        gradientTransform?: string;
        gradientUnits?: string;
        markerEnd?: string;
        markerMid?: string;
        markerStart?: string;
        offset?: number;
        opacity?: number;
        patternContentUnits?: string;
        patternUnits?: string;
        points?: string;
        preserveAspectRatio?: string;
        r?: number;
        rx?: number;
        ry?: number;
        spreadMethod?: string;
        stopColor?: string;
        stopOpacity?: number;
        stroke?: string;
        strokeDasharray?: string;
        strokeLinecap?: string;
        strokeOpacity?: number;
        strokeWidth?: number;
        textAnchor?: string;
        transform?: string;
        version?: string;
        viewBox?: string;
        x1?: number;
        x2?: number;
        x?: number;
        y1?: number;
        y2?: number;
        y?: number;
    }

    //
    // React.DOM
    // ----------------------------------------------------------------------

    interface ReactDOM {
        // HTML
        a: DOMFactory<HTMLAttributes>;
        abbr: DOMFactory<HTMLAttributes>;
        address: DOMFactory<HTMLAttributes>;
        area: DOMFactory<HTMLAttributes>;
        article: DOMFactory<HTMLAttributes>;
        aside: DOMFactory<HTMLAttributes>;
        audio: DOMFactory<HTMLAttributes>;
        b: DOMFactory<HTMLAttributes>;
        base: DOMFactory<HTMLAttributes>;
        bdi: DOMFactory<HTMLAttributes>;
        bdo: DOMFactory<HTMLAttributes>;
        big: DOMFactory<HTMLAttributes>;
        blockquote: DOMFactory<HTMLAttributes>;
        body: DOMFactory<HTMLAttributes>;
        br: DOMFactory<HTMLAttributes>;
        button: DOMFactory<HTMLAttributes>;
        canvas: DOMFactory<HTMLAttributes>;
        caption: DOMFactory<HTMLAttributes>;
        cite: DOMFactory<HTMLAttributes>;
        code: DOMFactory<HTMLAttributes>;
        col: DOMFactory<HTMLAttributes>;
        colgroup: DOMFactory<HTMLAttributes>;
        data: DOMFactory<HTMLAttributes>;
        datalist: DOMFactory<HTMLAttributes>;
        dd: DOMFactory<HTMLAttributes>;
        del: DOMFactory<HTMLAttributes>;
        details: DOMFactory<HTMLAttributes>;
        dfn: DOMFactory<HTMLAttributes>;
        dialog: DOMFactory<HTMLAttributes>;
        div: DOMFactory<HTMLAttributes>;
        dl: DOMFactory<HTMLAttributes>;
        dt: DOMFactory<HTMLAttributes>;
        em: DOMFactory<HTMLAttributes>;
        embed: DOMFactory<HTMLAttributes>;
        fieldset: DOMFactory<HTMLAttributes>;
        figcaption: DOMFactory<HTMLAttributes>;
        figure: DOMFactory<HTMLAttributes>;
        footer: DOMFactory<HTMLAttributes>;
        form: DOMFactory<HTMLAttributes>;
        h1: DOMFactory<HTMLAttributes>;
        h2: DOMFactory<HTMLAttributes>;
        h3: DOMFactory<HTMLAttributes>;
        h4: DOMFactory<HTMLAttributes>;
        h5: DOMFactory<HTMLAttributes>;
        h6: DOMFactory<HTMLAttributes>;
        head: DOMFactory<HTMLAttributes>;
        header: DOMFactory<HTMLAttributes>;
        hr: DOMFactory<HTMLAttributes>;
        html: DOMFactory<HTMLAttributes>;
        i: DOMFactory<HTMLAttributes>;
        iframe: DOMFactory<HTMLAttributes>;
        img: DOMFactory<HTMLAttributes>;
        input: DOMFactory<HTMLAttributes>;
        ins: DOMFactory<HTMLAttributes>;
        kbd: DOMFactory<HTMLAttributes>;
        keygen: DOMFactory<HTMLAttributes>;
        label: DOMFactory<HTMLAttributes>;
        legend: DOMFactory<HTMLAttributes>;
        li: DOMFactory<HTMLAttributes>;
        link: DOMFactory<HTMLAttributes>;
        main: DOMFactory<HTMLAttributes>;
        map: DOMFactory<HTMLAttributes>;
        mark: DOMFactory<HTMLAttributes>;
        menu: DOMFactory<HTMLAttributes>;
        menuitem: DOMFactory<HTMLAttributes>;
        meta: DOMFactory<HTMLAttributes>;
        meter: DOMFactory<HTMLAttributes>;
        nav: DOMFactory<HTMLAttributes>;
        noscript: DOMFactory<HTMLAttributes>;
        object: DOMFactory<HTMLAttributes>;
        ol: DOMFactory<HTMLAttributes>;
        optgroup: DOMFactory<HTMLAttributes>;
        option: DOMFactory<HTMLAttributes>;
        output: DOMFactory<HTMLAttributes>;
        p: DOMFactory<HTMLAttributes>;
        param: DOMFactory<HTMLAttributes>;
        picture: DOMFactory<HTMLAttributes>;
        pre: DOMFactory<HTMLAttributes>;
        progress: DOMFactory<HTMLAttributes>;
        q: DOMFactory<HTMLAttributes>;
        rp: DOMFactory<HTMLAttributes>;
        rt: DOMFactory<HTMLAttributes>;
        ruby: DOMFactory<HTMLAttributes>;
        s: DOMFactory<HTMLAttributes>;
        samp: DOMFactory<HTMLAttributes>;
        script: DOMFactory<HTMLAttributes>;
        section: DOMFactory<HTMLAttributes>;
        select: DOMFactory<HTMLAttributes>;
        small: DOMFactory<HTMLAttributes>;
        source: DOMFactory<HTMLAttributes>;
        span: DOMFactory<HTMLAttributes>;
        strong: DOMFactory<HTMLAttributes>;
        style: DOMFactory<HTMLAttributes>;
        sub: DOMFactory<HTMLAttributes>;
        summary: DOMFactory<HTMLAttributes>;
        sup: DOMFactory<HTMLAttributes>;
        table: DOMFactory<HTMLAttributes>;
        tbody: DOMFactory<HTMLAttributes>;
        td: DOMFactory<HTMLAttributes>;
        textarea: DOMFactory<HTMLAttributes>;
        tfoot: DOMFactory<HTMLAttributes>;
        th: DOMFactory<HTMLAttributes>;
        thead: DOMFactory<HTMLAttributes>;
        time: DOMFactory<HTMLAttributes>;
        title: DOMFactory<HTMLAttributes>;
        tr: DOMFactory<HTMLAttributes>;
        track: DOMFactory<HTMLAttributes>;
        u: DOMFactory<HTMLAttributes>;
        ul: DOMFactory<HTMLAttributes>;
        "var": DOMFactory<HTMLAttributes>;
        video: DOMFactory<HTMLAttributes>;
        wbr: DOMFactory<HTMLAttributes>;

        // SVG
        circle: DOMFactory<SVGAttributes>;
        defs: DOMFactory<SVGAttributes>;
        ellipse: DOMFactory<SVGAttributes>;
        g: DOMFactory<SVGAttributes>;
        line: DOMFactory<SVGAttributes>;
        linearGradient: DOMFactory<SVGAttributes>;
        mask: DOMFactory<SVGAttributes>;
        path: DOMFactory<SVGAttributes>;
        pattern: DOMFactory<SVGAttributes>;
        polygon: DOMFactory<SVGAttributes>;
        polyline: DOMFactory<SVGAttributes>;
        radialGradient: DOMFactory<SVGAttributes>;
        rect: DOMFactory<SVGAttributes>;
        stop: DOMFactory<SVGAttributes>;
        svg: DOMFactory<SVGAttributes>;
        text: DOMFactory<SVGAttributes>;
        tspan: DOMFactory<SVGAttributes>;
    }

    //
    // React.PropTypes
    // ----------------------------------------------------------------------

    interface Validator<T> {
        (object: T, key: string, componentName: string): Error;
    }

    interface Requireable<T> extends Validator<T> {
        isRequired: Validator<T>;
    }

    interface ValidationMap<T> {
        [key: string]: Validator<T>;
    }

    interface ReactPropTypes {
        any: Requireable<any>;
        array: Requireable<any>;
        bool: Requireable<any>;
        func: Requireable<any>;
        number: Requireable<any>;
        object: Requireable<any>;
        string: Requireable<any>;
        node: Requireable<any>;
        element: Requireable<any>;
        instanceOf(expectedClass: {}): Requireable<any>;
        oneOf(types: any[]): Requireable<any>;
        oneOfType(types: Validator<any>[]): Requireable<any>;
        arrayOf(type: Validator<any>): Requireable<any>;
        objectOf(type: Validator<any>): Requireable<any>;
        shape(type: ValidationMap<any>): Requireable<any>;
    }

    //
    // React.Children
    // ----------------------------------------------------------------------

    interface anyren {
        map<T>(children: any, fn: (child: any) => T): { [key:string]: T };
        forEach(children: any, fn: (child: any) => any): void;
        count(children: any): number;
        only(children: any): any;
    }

    //
    // Browser Interfaces
    // https://github.com/nikeee/2048-typescript/blob/master/2048/js/touch.d.ts
    // ----------------------------------------------------------------------

    interface AbstractView {
        styleMedia: StyleMedia;
        document: Document;
    }

    interface Touch {
        identifier: number;
        target: EventTarget;
        screenX: number;
        screenY: number;
        clientX: number;
        clientY: number;
        pageX: number;
        pageY: number;
    }

    interface TouchList {
        [index: number]: Touch;
        length: number;
        item(index: number): Touch;
        identifiedTouch(identifier: number): Touch;
    }
}
