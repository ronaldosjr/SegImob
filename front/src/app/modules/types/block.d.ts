export interface BlockDefinition {
  nextStatement: string;
  previousStatement: string;
  name: string;
  type: string;
  message0: string;
  args0: Args0[];
  output: null;
  colour: number;
  tooltip: string;
  helpUrl: string;
}

export interface Args0 {
  type: string;
  options?: Array<string[]>;
}

export interface CustomCrudButton {
  caption: string | undefined;
  icon: string | undefined;
  style: string | undefined;
  action: () => void;
}
